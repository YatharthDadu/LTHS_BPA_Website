"""Create one accurately bounded 2026-27 WSAP PDF for each published event."""

from pathlib import Path

from pypdf import PdfReader, PdfWriter

ROOT = Path(__file__).resolve().parents[1]
SOURCE = ROOT / "WSAP 2026-2027.pdf"
DESTINATION = ROOT / "guidelines" / "2026-2027"

# Printed page numbers from the official 2026-27 table of contents. Printed
# page 1 begins at PDF index 5, so a printed page N starts at index N + 4.
# Every event is included here, even those not shown in the site, to prevent a
# neighboring event from inheriting its pages.
SECTION_STARTS = {
    "V01": 47, "V02": 51, "V03": 55, "V04": 63, "V05": 71, "V06": 76,
    "V07": 81, "V08": 85, "V09": 89, "V10": 92, "V11": 97, "V12": 102,
    "V13": 106, "V14": 110, "V15": 115, "V16": 120,
    "100": 129, "105": 131, "110": 132, "115": 133, "125": 134, "135": 135,
    "145": 136, "150": 137, "155": 141, "160": 145, "165": 149, "190": 150,
    "200": 152, "205": 153, "210": 154, "215": 155, "220": 156, "225": 157,
    "230": 158, "235": 162, "240": 163, "245": 167, "250": 170, "290": 175,
    "291": 176, "292": 177, "293": 178,
    "300": 180, "305": 182, "310": 184, "315": 185, "320": 186, "325": 187,
    "330": 194, "335": 195, "340": 196, "345": 197, "350": 198, "355": 199,
    "360": 200, "365": 201, "390": 206, "391": 207,
    "400": 209, "405": 210, "410": 211, "420": 216, "425": 221, "430": 226,
    "440": 232, "445": 237, "450": 244, "455": 248, "460": 253, "490": 258,
    "500": 260, "505": 264, "510": 270, "590": 274,
    "600": 276, "605": 277, "610": 278, "615": 279, "690": 282,
    "700": 284, "705": 285, "710": 286, "715": 287, "720": 288, "725": 289,
    "730": 293, "735": 297, "740": 299, "745": 301, "750": 304, "755": 306,
    "760": 309, "790": 312,
}

# IDs shown on the chapter site. The omitted IDs remain above only as bounds.
PUBLISHED_EVENT_IDS = [
    *[f"V{number:02d}" for number in range(1, 17)],
    "100", "110", "125", "145", "150", "155", "160", "165", "190",
    "200", "205", "210", "215", "220", "225", "230", "235", "240", "245", "250", "290", "291", "292", "293",
    "300", "305", "310", "315", "320", "325", "330", "335", "340", "345", "350", "355", "360", "365", "390", "391",
    "400", "405", "410", "420", "425", "430", "440", "445", "450", "455", "460", "490",
    "500", "505", "510", "590", "600", "605", "610", "615", "690",
    "700", "705", "710", "715", "720", "725", "730", "735", "740", "745", "750", "755", "760", "790",
]


def main() -> None:
    if not SOURCE.exists():
        raise FileNotFoundError(f"Missing official guidebook: {SOURCE}")
    reader = PdfReader(SOURCE)
    DESTINATION.mkdir(parents=True, exist_ok=True)
    boundaries = sorted(SECTION_STARTS.values()) + [313]
    for event_id in PUBLISHED_EVENT_IDS:
        printed_start = SECTION_STARTS[event_id]
        printed_end = next(page for page in boundaries if page > printed_start)
        writer = PdfWriter()
        for physical_page in range(printed_start + 4, min(printed_end + 4, len(reader.pages))):
            writer.add_page(reader.pages[physical_page])
        with (DESTINATION / f"{event_id}.pdf").open("wb") as output:
            writer.write(output)
    print(f"Created {len(PUBLISHED_EVENT_IDS)} event PDFs in {DESTINATION}")


if __name__ == "__main__":
    main()
