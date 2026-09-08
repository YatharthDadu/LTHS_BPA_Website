from pathlib import Path
from pypdf import PdfReader, PdfWriter

ROOT = Path(__file__).resolve().parents[1]
SOURCE = ROOT / "WSAP 2025-2026.pdf"
DESTINATION = ROOT / "guidelines" / "2025-2026"

# Printed page numbers from the official table of contents. The PDF's front matter
# occupies five physical pages before printed page 1.
START_PAGES = {
    "V01": 40, "V02": 44, "V03": 48, "V04": 55, "V05": 62, "V06": 67,
    "V07": 72, "V08": 76, "V09": 80, "V10": 83, "V11": 89, "V12": 94,
    "V13": 98, "V14": 102, "V15": 107,
    "100": 113, "110": 115, "125": 117, "145": 119, "150": 120, "155": 124,
    "160": 128, "165": 132, "190": 133,
    "200": 135, "205": 136, "210": 137, "215": 138, "220": 139, "225": 140,
    "230": 141, "235": 142, "240": 143, "245": 144, "255": 145, "260": 146,
    "265": 150, "290": 151,
    "300": 153, "305": 154, "310": 155, "315": 156, "320": 157, "325": 158,
    "330": 164, "335": 165, "340": 166, "345": 167, "350": 168, "355": 169,
    "390": 170, "391": 171,
    "400": 173, "405": 174, "410": 175, "415": 180, "420": 181, "425": 186,
    "430": 191, "435": 197, "440": 201, "445": 206, "450": 212, "455": 216,
    "460": 221, "490": 226,
    "500": 228, "505": 232, "510": 236, "515": 239, "520": 243, "525": 247,
    "535": 251, "540": 253, "545": 255, "550": 257, "555": 262, "560": 265,
    "590": 268, "591": 269, "592": 270, "594": 272,
    "600": 274, "605": 275, "610": 276, "615": 277, "690": 279,
}

reader = PdfReader(SOURCE)
DESTINATION.mkdir(parents=True, exist_ok=True)

# Boundaries also include events that are deliberately not published on the site.
# They are still required so a neighboring event never inherits their pages.
SECTION_STARTS = sorted([
    *START_PAGES.items(),
    ("105", 114), ("115", 116), ("135", 118), ("530", 249), ("593", 271),
    ("_after_last_event", 280),
], key=lambda item: item[1])

for event_id, printed_start in START_PAGES.items():
    writer = PdfWriter()
    next_printed_start = next(page for _, page in SECTION_STARTS if page > printed_start)
    # pypdf page indexes are zero-based; printed page 1 is PDF page 6.
    physical_start = printed_start + 4
    physical_end = min(next_printed_start + 4, len(reader.pages))
    for physical_page in range(physical_start, physical_end):
        writer.add_page(reader.pages[physical_page])
    with (DESTINATION / f"{event_id}.pdf").open("wb") as output:
        writer.write(output)

print(f"Created {len(START_PAGES)} event PDFs in {DESTINATION}")
