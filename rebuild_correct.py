"""
FINAL CORRECT rebuild of practiceTests in events-db.js

Maps old PDF number prefixes to the correct 2026-2027 event IDs.
Excludes answer keys, rubrics, and deduplicates.
"""
import json, re, os

# ============================================================
# Load current events-db.js
# ============================================================
with open('events-db.js', 'r', encoding='utf-8') as f:
    raw = f.read()

js_body = re.sub(r'^.*?window\.bpaEvents\s*=\s*', '', raw, flags=re.DOTALL).rstrip().rstrip(';')
data = json.loads(js_body)

# ============================================================
# Filter functions
# ============================================================
def is_answer_key(filename):
    """Return True if the file is an answer key."""
    # _KEY_ (case insensitive)
    if re.search(r'[_\-]KEY[_\-.]', filename, re.IGNORECASE):
        return True
    # _Key.pdf or -Key.pdf at end
    if re.search(r'[_\-]Key\.pdf$', filename, re.IGNORECASE):
        return True
    # answer or solution
    if re.search(r'\b(answer|answers|solution|solutions)\b', filename, re.IGNORECASE):
        return True
    return False

def is_rubric(filename):
    """Return True if the file is a rubric (not a practice test)."""
    return bool(re.search(r'\brubric\b', filename, re.IGNORECASE))

# ============================================================
# Collect all valid PDF files indexed by numeric prefix
# ============================================================
all_pdfs_by_prefix = {}  # prefix(str) -> list of {"name": fname, "url": rel_url}

for root, dirs, files in os.walk('PracticeTests'):
    dirs.sort()
    for f in sorted(files):
        if not f.lower().endswith('.pdf'):
            continue
        if is_answer_key(f):
            continue
        if is_rubric(f):
            continue
        m = re.match(r'^(\d+)', f)
        if not m:
            continue
        prefix = m.group(1)
        rel_path = os.path.join(root, f).replace('\\', '/')
        # Fix double .pdf.pdf
        rel_path = re.sub(r'\.pdf\.pdf$', '.pdf', rel_path, flags=re.IGNORECASE)
        fname = re.sub(r'\.pdf\.pdf$', '.pdf', f, flags=re.IGNORECASE)
        
        if prefix not in all_pdfs_by_prefix:
            all_pdfs_by_prefix[prefix] = []
        entry = {"name": fname, "url": rel_path}
        # Deduplicate by URL
        if not any(e['url'] == rel_path for e in all_pdfs_by_prefix[prefix]):
            all_pdfs_by_prefix[prefix].append(entry)

# Also deduplicate by filename (keep first occurrence only)
for prefix in all_pdfs_by_prefix:
    seen_names = set()
    deduped = []
    for entry in all_pdfs_by_prefix[prefix]:
        if entry['name'] not in seen_names:
            seen_names.add(entry['name'])
            deduped.append(entry)
    all_pdfs_by_prefix[prefix] = deduped

# ============================================================
# The mapping: old PDF prefix -> new 2026-2027 event ID
#
# Based on careful cross-referencing of:
# 1) 2025 PDF filenames (which show the old event names)
# 2) 2026-2027 event titles in events-db.js
# 
# RULE: If old prefix == new event ID (same number), we only use it if
#       the PDF event name actually matches the new event title.
#       If they don't match (renumbered events), we use the override.
#
# KEY RENUMBERINGS in 2026-2027:
# - Old 200-series Word Processing (200,205,210) -> New 700-series (700,705,710)
# - Old 200-series Administrative (215,220,225,230,235,240,245,255,260,265) 
#   -> New condensed 200-series (200,215,205,210,215,220,225,230,235)
# - Old 500-series Career (515,520,525,530,535,540,545,550,555) 
#   -> New 700-series Career (725,730,735,740,745,750,755,250,760)
# ============================================================

# Map: old_prefix -> list of new event IDs (usually just one)
# Using explicit title-based mapping
PREFIX_TO_EVENT = {
    # ==== 100-series Finance ====
    # These are the same events with same numbers
    '100': ['100'],   # Fundamental Accounting
    '110': ['110'],   # Advanced Accounting
    # 105 = College Accounting -> no current event 105 in new db? 
    # (skipping 105, 115, 130, 135, 140 as they're not in current events-db)
    '125': ['125'],   # Payroll Accounting
    '135': ['135'],   # Managerial Accounting (if event 135 exists)
    '145': ['145'],   # Banking & Finance
    '150': ['150'],   # Financial Analyst Team
    '155': ['155'],   # Economic Research Individual (presentations - these are actually tests)
    '160': ['160'],   # Economic Research Team (presentations)
    '165': ['165'],   # Personal Financial Management
    '190': ['190'],   # Financial Services Concepts (Open)
    
    # ==== 200-series: CRITICAL RENAMING ====
    # Old prefix 200 = Fundamental Word Processing -> New event 700
    '200': ['700'],
    # Old prefix 205 = Intermediate Word Processing -> New event 705
    '205': ['705'],
    # Old prefix 210 = Advanced Word Processing -> New event 710
    '210': ['710'],
    # Old prefix 215 = Integrated Office Applications -> New event 200
    '215': ['200'],
    # Old prefix 220 = Basic Office Systems & Procedures -> DISCONTINUED (no match in 2026-2027)
    # [skip 220]
    # Old prefix 225 = Advanced Office Systems & Procedures -> DISCONTINUED
    # [skip 225]
    # Old prefix 230 = Fundamental Spreadsheet Applications -> New event 205
    '230': ['205'],
    # Old prefix 235 = Advanced Spreadsheet Applications -> New event 210
    '235': ['210'],
    # Old prefix 240 = Database Applications -> New event 215
    '240': ['215'],
    # Old prefix 245 = Legal Office Procedures -> New event 220
    '245': ['220'],
    # Old prefix 250 = Medical Office Procedures -> no current match (discontinued)
    # [skip 250]
    # Old prefix 255 = Administrative Support Team -> New event 225
    '255': ['225'],
    # Old prefix 260 = Admin Support Research Project -> New event 230 (Admin Trends Research)
    '260': ['230'],
    # Old prefix 265 = Business Law & Ethics -> New event 235
    '265': ['235'],
    # 270 = ICD-10 -> discontinued (no match)
    # [skip 270]
    # 290 = Admin Support Concepts -> event 290
    '290': ['290'],
    
    # ==== 300-series Technology: same IDs ====
    '300': ['300'],
    '305': ['305'],
    '310': ['310'],
    '315': ['315'],
    '320': ['320'],
    '325': ['325'],
    '330': ['330'],
    '335': ['335'],
    '340': ['340'],
    '345': ['345'],
    '350': ['350'],
    '355': ['355'],
    '390': ['390'],
    '391': ['391'],
    
    # ==== 400-series Design ====
    '400': ['400'],   # Fundamental Desktop Publishing
    '405': ['405'],   # Advanced Desktop Publishing (was 405 Fundamentals of Web Design? 
                      # 2025 shows 405_N_Advanced Desktop Publishing so same ID)
    '415': [],        # Fundamentals of Web Design (2025) -> no current match in 2026-2027 db
                      # (new event 405 is Adv Desktop Publishing, not Fundamentals of Web Design)
    '410': ['410'],   # Graphic Design Promotion
    '420': ['420'],   # Digital Media Production
    '425': ['425'],   # Computer Modeling
    '430': ['430'],   # Video Production Team
    '435': [],        # Website Design Team -> no current match (old 435 doesn't match any new event)
    '440': ['440'],   # Computer Animation Team
    '445': ['445'],   # Broadcast News Production Team
    '450': ['450'],   # Podcast Production Team
    '455': ['455'],   # User Experience Design Team
    '460': ['460'],   # Visual Design Team
    '490': ['490'],   # Digital Comm & Design Concepts
    
    # ==== 500-series Marketing ====
    '500': ['500'],   # Global Marketing Strategy Team
    '505': ['505'],   # Entrepreneurship (pilot) 
    '510': ['510'],   # Small Business Management / Industry Pitch Team
    '590': ['590'],   # Marketing & Sales Concepts (Open)
    
    # ==== Career Skills: OLD 515-560 -> NEW 725-760 ====
    # These were all in the 500-series as "career skills" events
    # but existed as separate events. In 2026-2027 they're 700-series.
    '515': ['725'],   # Interview Skills
    '520': ['730'],   # Advanced Interview Skills
    '525': ['735'],   # Extemporaneous Speech
    '530': ['740'],   # Contemporary Issues
    '535': ['745'],   # Human Resource Management
    '540': ['750'],   # Ethics and Professionalism
    '545': ['755'],   # Prepared Speech
    '550': ['250'],   # Parliamentary Procedure Team -> moved to 250 (management section)
    '555': ['760'],   # Presentation Individual
    # Old 560 = Presentation Management Team -> no current match
    # [skip 560]
    
    # ==== 590-594: Old concept events ====
    # These have numbers that CONFLICT with current event 590
    # Old PDF 590 = Meeting & Event Planning Concepts -> new 293? 
    # But new 293 is empty. Let's add them.
    # Actually: new event 590 = "MARKETING & SALES CONCEPTS (OPEN)"
    # Old prefix 590 PDFs = "Meeting and Event Planning Concepts"
    # These DON'T match -> skip old 590 for event 590
    # Old 591 = "Management, Marketing & HR Concepts" -> no current match
    # Old 592 = "Parliamentary Procedure Concepts" -> new 291?
    # Old 593 = "Project Management Concepts" -> new 292?
    # Old 594 = "Digital Marketing Concepts" -> new 590? ("Marketing & Sales Concepts")
    # Given ambiguity, let's be conservative:
    # '591': [], '592': ['291'], '593': ['292'],
    # Actually let's NOT map these old concepts to new concept events 
    # since the content may differ
    
    # ==== 600-series Health ====
    '600': ['600'],   # Medical Coding
    '605': ['605'],   # Health Insurance & Medical Billing
    '610': ['610'],   # Health Administration Procedures
    '690': ['690'],   # Health Administration Concepts (Open)
    # 615 = Health Admin Leadership Special Topics (old) -> new 615 = Health Trends Research Presentation
    # These are rubrics only so they were filtered out already
    # 616 = Health Research Presentation -> new 615?
    '616': ['615'],   # Health Research Presentation -> Health Trends Research Presentation
    '620': [],        # Medical Terminology Concepts (Old) -> no current match
}

# ============================================================
# Rebuild practiceTests for each event
# ============================================================
for eid in data:
    data[eid]['practiceTests'] = []

# Apply mapping
assigned = 0
for old_prefix, new_event_ids in PREFIX_TO_EVENT.items():
    pdfs = all_pdfs_by_prefix.get(old_prefix, [])
    if not pdfs:
        continue
    for new_eid in new_event_ids:
        if new_eid not in data:
            print(f"WARNING: Event {new_eid} not found in data (from prefix {old_prefix})")
            continue
        # Add PDFs, avoiding duplicates
        existing_urls = {t['url'] for t in data[new_eid]['practiceTests']}
        existing_names = {t['name'] for t in data[new_eid]['practiceTests']}
        for pdf in pdfs:
            if pdf['url'] not in existing_urls and pdf['name'] not in existing_names:
                data[new_eid]['practiceTests'].append(pdf)
                existing_urls.add(pdf['url'])
                existing_names.add(pdf['name'])
        assigned += len(pdfs)

# Sort each event's practice tests (by name for consistency)
for eid in data:
    data[eid]['practiceTests'].sort(key=lambda x: x['name'])

# ============================================================
# Report
# ============================================================
events_with_tests = [(eid, len(data[eid]['practiceTests'])) for eid in data if data[eid]['practiceTests']]
events_without_tests = [(eid, data[eid]['title'][:50]) for eid in data if not data[eid]['practiceTests'] and not eid.startswith('V')]

print(f"Events WITH practice tests: {len(events_with_tests)}")
print(f"Events WITHOUT practice tests (non-virtual): {len(events_without_tests)}")

print("\nEvents with practice tests (count):")
for eid, count in sorted(events_with_tests, key=lambda x: (len(x[0]), x[0])):
    print(f"  {eid}: {data[eid]['title'][:50]} ({count} tests)")

print("\nEvents WITHOUT tests (non-virtual):")
for eid, title in sorted(events_without_tests, key=lambda x: (len(x[0]), x[0])):
    print(f"  {eid}: {title}")

# ============================================================
# Spot checks
# ============================================================
print("\n=== Spot checks ===")
checks = [
    ('700', 'FUNDAMENTAL WORD PROCESSING', '200_'),
    ('705', 'INTERMEDIATE WORD PROCESSING', '205_'),
    ('710', 'ADVANCED WORD PROCESSING', '210_'),
    ('200', 'INTEGRATED OFFICE APPLICATIONS', '215_'),
    ('205', 'FUNDAMENTAL SPREADSHEET APPLICATIONS', '230_'),
    ('210', 'ADVANCED SPREADSHEET APPLICATIONS', '235_'),
    ('215', 'DATABASE APPLICATIONS', '240_'),
    ('220', 'LEGAL OFFICE PROCEDURES', '245_'),
    ('225', 'ADMINISTRATIVE SUPPORT TEAM', '255_'),
    ('235', 'BUSINESS LAW AND ETHICS', '265_'),
    ('250', 'PARLIAMENTARY PROCEDURE TEAM', '550_'),
    ('725', 'INTERVIEW SKILLS', '515_'),
    ('740', 'CONTEMPORARY ISSUES', '530_'),
    ('100', 'FUNDAMENTAL ACCOUNTING', '100_'),
    ('300', 'COMPUTER NETWORK TECHNOLOGY', '300_'),
]
for eid, expected_title, expected_prefix in checks:
    if eid not in data:
        print(f"  MISSING event {eid}")
        continue
    actual_title = data[eid]['title'][:len(expected_title)]
    tests = data[eid]['practiceTests']
    if not tests:
        print(f"  {eid}: NO TESTS (expected prefix {expected_prefix})")
        continue
    first = tests[0]['name']
    ok = first.startswith(expected_prefix)
    status = "OK" if ok else "WRONG"
    print(f"  {status}: Event {eid} ({actual_title[:35]}) first test: {first[:50]}")

# ============================================================
# Write updated events-db.js
# ============================================================
# Reconstruct the JS file
header = "// Generated from the official 2026-2027 WSAP v1.0.\nwindow.bpaEvents = "
json_str = json.dumps(data, indent=4, ensure_ascii=False)
output = header + json_str + ";\n"

with open('events-db.js', 'w', encoding='utf-8') as f:
    f.write(output)

print(f"\nWrote events-db.js ({len(output):,} bytes)")
print("Done!")
