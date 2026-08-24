import PyPDF2
import re
import json

def main():
    reader = PyPDF2.PdfReader('WSAP 2025-2026.pdf')
    text = ''
    for page in reader.pages:
        text += page.extract_text() + '\n'
    
    events = {}
    lines = text.split('\n')
    
    current_event_id = None
    current_event_title = None
    current_description = []
    in_description = False
    
    for line in lines:
        line = line.strip()
        
        m = re.match(r'^\(([A-Z0-9]{3})\)\s+(.*)$', line)
        if m:
            if current_event_id and current_description:
                events[current_event_id] = {
                    "id": current_event_id,
                    "title": current_event_title,
                    "description": " ".join(current_description)
                }
            
            current_event_id = m.group(1)
            current_event_title = re.sub(r'(SECONDARY EVENT ONLY|POSTSECONDARY EVENT ONLY).*$', '', m.group(2)).strip()
            current_description = []
            in_description = False
            continue
            
        if current_event_id:
            if "Description & Eligibility" in line:
                in_description = True
                current_description = []
                continue
                
            if in_description:
                if line.startswith("Contestant Must Supply") or line.startswith("Equipment/Supplies") or line.startswith("Topic") or line.startswith("Competition Notes"):
                    in_description = False
                    events[current_event_id] = {
                        "id": current_event_id,
                        "title": current_event_title,
                        "description": " ".join(current_description).strip()
                    }
                    current_event_id = None
                elif line:
                    current_description.append(line)

    if current_event_id and current_description:
        events[current_event_id] = {
            "id": current_event_id,
            "title": current_event_title,
            "description": " ".join(current_description).strip()
        }
        
    js_content = "// Centralized Database for BPA Events\n// Generated from WSAP 2025-2026.pdf\nwindow.bpaEvents = {\n"
    for key, event in events.items():
        js_content += f'    "{key}": {{\n'
        js_content += f'        id: "{event["id"]}",\n'
        js_content += f'        title: {json.dumps(event["title"])},\n'
        js_content += f'        description: {json.dumps(event["description"])},\n'
        js_content += f'        wsapLink: "#",\n'
        js_content += f'        quizzes: [],\n'
        js_content += f'        generatorLink: "#"\n'
        js_content += f'    }},\n'
    js_content += "};\n"
    
    with open('events-db.js', 'w', encoding='utf-8') as f:
        f.write(js_content)

if __name__ == '__main__':
    main()
