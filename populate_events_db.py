import json
import re
import os

md_file_path = r"C:\Users\Owner\.gemini\antigravity\brain\d74502e4-bd71-4e0f-8295-a7e8d93156e6\event_descriptions.md"
js_file_path = r"c:\Users\Owner\Downloads\NewBPAWebsite\events-db.js"

with open(md_file_path, "r", encoding="utf-8") as f:
    content = f.read()

events = {}
lines = content.split('\n')

for line in lines:
    line = line.strip()
    if line.startswith('* **'):
        # match format: * **(Event Code) Event Name:** Description
        m = re.match(r'\*\s+\*\*\((.*?)\)\s+(.*?):\*\*\s+(.*)', line)
        if m:
            event_code = m.group(1).strip()
            event_name = m.group(2).strip()
            description = m.group(3).strip()
            
            events[event_code] = {
                "id": event_code,
                "title": event_name.upper(),
                "description": description,
                "wsapLink": "#",
                "quizzes": [],
                "generatorLink": "#"
            }

js_output = "// Centralized Database for BPA Events\n// Auto-populated from WSAP 2025-2026.pdf\nwindow.bpaEvents = {\n"
for code, data in events.items():
    js_output += f'    "{code}": {{\n'
    js_output += f'        id: "{data["id"]}",\n'
    js_output += f'        title: {json.dumps(data["title"])},\n'
    js_output += f'        description: {json.dumps(data["description"])},\n'
    js_output += f'        wsapLink: "#",\n'
    js_output += f'        quizzes: [],\n'
    js_output += f'        generatorLink: "#"\n'
    js_output += f'    }},\n'
js_output += "};\n"

with open(js_file_path, "w", encoding="utf-8") as f:
    f.write(js_output)

print(f"Successfully populated {len(events)} events into {js_file_path}")
