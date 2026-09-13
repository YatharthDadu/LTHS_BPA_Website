import json
import re

user_events = []
with open('user_events.txt', 'r', encoding='windows-1252') as f:
    for line in f:
        line = line.strip()
        if not line: continue
        m = re.match(r'\(?(\d{3})\)?\s+(.*)', line)
        if m:
            title = m.group(2).strip()
            user_events.append({'id': m.group(1), 'title': title})

# Extract descriptions from existing HTML
with open('competitions.html', 'r', encoding='utf-8') as f:
    html = f.read()

existing_desc = {}
ticket_pattern = re.compile(r'<span class="ticket-serial">(\d{3})</span>.*?<p class="ticket-mini-desc"[^>]*>(.*?)</p>', re.DOTALL)
for m in ticket_pattern.finditer(html):
    eid = m.group(1)
    desc = m.group(2)
    existing_desc[eid] = desc

db_events = {}
for ev in user_events:
    eid = ev['id']
    title = ev['title']
    desc = existing_desc.get(eid, "Description coming soon.")
    db_events[eid] = {
        'id': eid,
        'title': title.upper(),
        'description': desc,
        'wsapLink': '#',
        'quizzes': [],
        'generatorLink': '#'
    }

db_content = "// Centralized Database for BPA Events\nwindow.bpaEvents = " + json.dumps(db_events, indent=4) + ";"
with open('events-db.js', 'w', encoding='utf-8') as f:
    f.write(db_content)

print("Updated events-db.js")
