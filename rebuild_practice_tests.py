import os, re, json, shutil

KEY_PATTERN = re.compile(r'(?i)([-_\s]key[-_\s\.]|answer|solution|[-_\s]ak[-_\s\.])')
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
        parts = root.replace('\\\\\\\\', '/').replace('\\\\', '/')
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
            rel_path = os.path.relpath(os.path.join(root, filename), start='.').replace('\\\\\\\\', '/').replace('\\\\', '/')
            entry = {'name': filename, 'url': rel_path}
            practice_tests_map.setdefault(ev_id, []).append(entry)
    return practice_tests_map

pt_dir = 'PracticeTests'
practice_tests_map = build_practice_tests_map(pt_dir)
for ev_id in practice_tests_map:
    practice_tests_map[ev_id].sort(key=lambda x: x['name'])

shutil.copy('events-db.js', 'events-db.js.bak')

with open('events-db.js', 'r', encoding='utf-8') as f:
    content = f.read()

defined_ids = re.findall(r'"id":\s*"([^"]+)"', content)
print('Events in DB:', len(defined_ids))

new_content = content
no_match = []
updated = []

for ev_id in defined_ids:
    tests = practice_tests_map.get(ev_id, [])
    tests_json = json.dumps(tests, ensure_ascii=False)
    id_marker = '"id": "' + ev_id + '"'
    pos = new_content.find(id_marker)
    if pos == -1:
        no_match.append(ev_id)
        continue
    pt_start_label = new_content.find('"practiceTests":', pos)
    if pt_start_label == -1 or pt_start_label - pos > 3000:
        no_match.append(ev_id)
        continue
    bracket_start = new_content.index('[', pt_start_label)
    depth = 0
    i = bracket_start
    while i < len(new_content):
        c = new_content[i]
        if c == '[':
            depth += 1
        elif c == ']':
            depth -= 1
            if depth == 0:
                bracket_end = i
                break
        i += 1
    new_content = new_content[:bracket_start] + tests_json + new_content[bracket_end+1:]
    updated.append(ev_id)

print('Updated:', len(updated), 'events')
if no_match:
    print('Could not update:', no_match)

with open('events-db.js', 'w', encoding='utf-8') as f:
    f.write(new_content)

print('Done!')
