"""Build the chapter catalog from the official 2026-27 guidebook."""

import json
import re
from pathlib import Path

from pypdf import PdfReader

from extract_event_pdfs import PUBLISHED_EVENT_IDS, SECTION_STARTS

ROOT = Path(__file__).resolve().parents[1]
SOURCE = ROOT / "WSAP 2026-2027.pdf"
OUTPUT = ROOT / "events-db.js"


def normalize(value: str) -> str:
    value = value.replace("\u00ad", "").replace("\u2011", "-")
    value = re.sub(r"\s*-\s*", "-", value)
    return re.sub(r"\s+", " ", value).strip()


def first_sentence(value: str) -> str:
    match = re.search(r"(.+?[.!?])(?=\s|$)", value)
    return match.group(1) if match else value


def title_for(event_id: str, section: str) -> str:
    match = re.search(rf"\b{re.escape(event_id)}\s+(.+?)\s+Description\s+(?:&|and)\s+Eligibility", section, re.I | re.S)
    if not match:
        raise ValueError(f"Could not locate title for {event_id}")
    title = re.sub(r"\s*\(\s*(?:formerly|new\s*\d*\s*event).*?\)", "", normalize(match.group(1)), flags=re.I)
    return title.upper()


def description_for(section: str) -> str:
    description_match = re.search(
        r"Description\s+(?:&|and)\s+Eligibility\s+(.*?)(?=\s+(?:Contestant|Team) Must Supply|\s+Competition Notes|\s+Contest Notes)",
        section, re.I | re.S,
    )
    if not description_match:
        raise ValueError("Could not locate event description")
    description = first_sentence(normalize(description_match.group(1)))
    competency_match = re.search(r"(?:Contest\s+)?Competencies\s+(.*)", section, re.I | re.S)
    competencies = []
    if competency_match:
        competencies = [normalize(item) for item in re.findall(
            r"\b\d+\.\s+(.*?)(?=\s+\d+\.\s+|\s+(?:SECONDARY|POSTSECONDARY) EVENT ONLY|\s+Business Professionals|$)", competency_match.group(1), re.S | re.I
        )]
    if not competencies:
        raise ValueError("Could not locate event competencies")
    return f"{description} Core competencies assessed include, but are not limited to, {'; '.join(competencies[:2])}."


def main() -> None:
    reader = PdfReader(SOURCE)
    starts = sorted(SECTION_STARTS.values()) + [313]
    events = {}
    for event_id in PUBLISHED_EVENT_IDS:
        start = SECTION_STARTS[event_id]
        end = next(page for page in starts if page > start)
        section = "\n".join(reader.pages[index].extract_text() or "" for index in range(start + 4, min(end + 4, len(reader.pages))))
        events[event_id] = {
            "id": event_id,
            "title": title_for(event_id, section),
            "description": description_for(section),
            "wsapLink": "#",
            "quizzes": [],
            "generatorLink": "#",
        }
    OUTPUT.write_text("// Generated from the official 2026-2027 WSAP v1.0.\nwindow.bpaEvents = " + json.dumps(events, indent=4) + ";\n", encoding="utf-8")
    print(f"Created {len(events)} official event records in {OUTPUT}")


if __name__ == "__main__":
    main()
