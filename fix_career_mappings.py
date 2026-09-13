import os, re, json

KEY_PATTERN = re.compile(r'(?i)(_KEY_|_KEY\b|_AK_|\bAK\b|answer|solution|_Key_|\bKey\b)')

def is_answer_key(filename):
    return bool(KEY_PATTERN.search(filename))

EVENT_PREFIX = re.compile(r'^([A-Z]?\d{1,3}[A-Z]?)[\s_]', re.IGNORECASE)

def extract_event_id(filename):
    m = EVENT_PREFIX.match(filename)
    if m:
        return m.group(1).upper()
    return None

def build_practice_tests_map(pt_dir):
    practice_tests_map = {}
    for root, dirs, files in os.walk(pt_dir):
        parts = root.replace('\\\\', '/').replace('\\', '/')
        if 'Student Files' in parts or 'Student Fillable' in parts:
            continue
        for filename in files:
            if not filename.lower().endswith('.pdf'):
                continue
            if is_answer_key(filename):
                continue
            ev_id = extract_event_id(filename)
            if not ev_id:
                continue
            rel_path = os.path.relpath(os.path.join(root, filename), start='.').replace('\\', '/')
            entry = {'name': filename, 'url': rel_path}
            practice_tests_map.setdefault(ev_id, []).append(entry)
    return practice_tests_map

pt_dir = 'PracticeTests'
practice_tests_map = build_practice_tests_map(pt_dir)
for ev_id in practice_tests_map:
    practice_tests_map[ev_id].sort(key=lambda x: x['name'])

# Old-to-new career skills event ID mapping (where old event PDFs are available)
# Based on WSAP 2026-2027 renaming of career events
old_to_new_career = {
    '515': '725',   # Interview Skills
    '520': '730',   # Advanced Interview Skills  
    '525': '735',   # Extemporaneous Speech
    '530': '740',   # Contemporary Issues
    '535': '745',   # Human Resource Management
    '540': '750',   # Ethics and Professionalism
    '545': '755',   # Prepared Speech
    '555': '760',   # Presentation Individual (was 555, now 760)
    '560': '780',   # Presentation Team (was 560)
    # 550 = Parli Procedure Team stays as 550 in practice tests but doesn't map to 700-series
    # 591 = Meeting & Event Planning Concepts -> 590 (already handled)
}

# Also add alias data: add old-numbered tests to new-numbered events
with open('events-db.js', 'r', encoding='utf-8') as f:
    content = f.read()

def update_event_tests(content, ev_id, tests):
    tests_json = json.dumps(tests, ensure_ascii=False)
    id_marker = '"id": "' + ev_id + '"'
    pos = content.find(id_marker)
    if pos == -1:
        return content, False
    pt_start_label = content.find('"practiceTests":', pos)
    if pt_start_label == -1 or pt_start_label - pos > 3000:
        return content, False
    bracket_start = content.index('[', pt_start_label)
    depth = 0
    i = bracket_start
    while i < len(content):
        c = content[i]
        if c == '[':
            depth += 1
        elif c == ']':
            depth -= 1
            if depth == 0:
                bracket_end = i
                break
        i += 1
    content = content[:bracket_start] + tests_json + content[bracket_end+1:]
    return content, True

# Apply career skills mappings
updated_career = []
for old_id, new_id in old_to_new_career.items():
    tests = practice_tests_map.get(old_id, [])
    if tests:
        content, ok = update_event_tests(content, new_id, tests)
        if ok:
            updated_career.append(f'{old_id}->{new_id} ({len(tests)} tests)')

# Also handle Parli Procedure Concepts/Team in career (592 = Parli Concepts, 550 = Parli Team)
# 550 in competition catalog is under management (not career), so it should already be populated

print('Career mappings applied:', updated_career)

with open('events-db.js', 'w', encoding='utf-8') as f:
    f.write(content)

print('Done!')
