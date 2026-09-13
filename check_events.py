import json, re, os

# Load current events DB
with open('events-db.js', 'r', encoding='utf-8') as f:
    content = f.read()
js = re.sub(r'^.*?window\.bpaEvents\s*=\s*', '', content, flags=re.DOTALL).rstrip().rstrip(';')
current_data = json.loads(js)

# Collect ALL PDF files
all_pdfs = {}  # prefix -> list of (rel_path, filename)
for root, dirs, files in os.walk('PracticeTests'):
    for f in files:
        if not f.lower().endswith('.pdf'):
            continue
        m = re.match(r'^(\d+)', f)
        if m:
            prefix = m.group(1)
            if prefix not in all_pdfs:
                all_pdfs[prefix] = []
            rel_path = os.path.join(root, f).replace('\\', '/')
            all_pdfs[prefix].append((rel_path, f))

def is_answer_key(filename):
    # More comprehensive key detection
    name = filename
    # Specific _KEY_ patterns (case variations)
    if re.search(r'[_\-\s]KEY[_\-\s.]', name, re.IGNORECASE):
        return True
    # -Key. pattern (end of name before extension)
    if re.search(r'-Key\.pdf$', name, re.IGNORECASE):
        return True
    # _Key.pdf pattern
    if re.search(r'_Key\.pdf$', name, re.IGNORECASE):
        return True
    # answer, solution
    if re.search(r'\b(answer|solution|answers|solutions)\b', name, re.IGNORECASE):
        return True
    return False

def is_rubric(filename):
    return bool(re.search(r'\brubric\b', filename, re.IGNORECASE))

# For each current event, determine what OLD prefix should map to it
# Based on the event title similarities
# KEY INSIGHT: Old prefix X has PDF files named "X_EventTitle..."
# We need to map old prefix -> new event ID

# Extract event name from PDF filename
def extract_event_name_from_pdf(filename):
    # Remove prefix, year, S/N indicators, etc.
    name = re.sub(r'^\d+[_\-\s]+', '', filename)
    name = re.sub(r'[_\-\s]+(S|N|State|National|Prelim|Final|Prelims|Finals|Concepts|Open)[_\-\s]+', ' ', name, flags=re.IGNORECASE)
    name = re.sub(r'[_\-\s]+\d{4}.*', '', name)
    name = re.sub(r'[_\-]+', ' ', name).strip()
    return name

# Show what each old prefix's PDFs are named
print("=== Old prefix -> event name mapping (from 2025 PDFs) ===")
for prefix in sorted(all_pdfs.keys(), key=lambda x: int(x) if x.isdigit() else 9999):
    if not prefix.isdigit():
        continue
    files = all_pdfs[prefix]
    # Get 2025 files first, otherwise any
    f2025 = [(p,f) for p,f in files if '2025' in f and not is_answer_key(f) and not is_rubric(f)]
    if not f2025:
        f2025 = [(p,f) for p,f in files if not is_answer_key(f) and not is_rubric(f)]
    if f2025:
        _, fname = f2025[0]
        event_name = extract_event_name_from_pdf(fname)
        print(f"  {prefix}: {fname[:70]}")

# Now let's build the correct mapping
# For each current event ID, find which OLD prefix best matches it
print("\n\n=== Current event -> correct old prefix mapping ===")

# All old prefixes (that differ from current IDs)
old_prefixes_not_matching = ['200', '205', '210', '215', '220', '225', '230', '235', '240', 
                               '245', '250', '255', '260', '265', '270',
                               '515', '520', '525', '530', '535', '540', '545', '550', '555', '560',
                               '591', '592', '593', '594']

# Current events that need to be mapped
for eid in sorted(current_data.keys(), key=lambda x: (len(x), x)):
    if not eid.isdigit():
        continue
    evt = current_data[eid]
    title = evt['title']
    tests = evt.get('practiceTests', [])
    
    # Check if this event has tests with WRONG prefixes
    wrong_tests = []
    for t in tests:
        m = re.match(r'^(\d+)', t['name'])
        if m and m.group(1) != eid:
            wrong_tests.append((m.group(1), t['name'][:50]))
    
    if wrong_tests:
        wrong_prefix = wrong_tests[0][0]
        print(f"  Event {eid} '{title[:40]}' has tests from prefix {wrong_prefix}")
