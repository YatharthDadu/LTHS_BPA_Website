import os
import re
import json

def main():
    practice_tests_map = {}
    pt_dir = 'PracticeTests'
    if os.path.exists(pt_dir):
        for root, dirs, files in os.walk(pt_dir):
            for file in files:
                if file.lower().endswith('.pdf'):
                    if 'key' in file.lower():
                        continue
                    m_id = re.match(r'^([A-Z0-9]{3})', file, re.IGNORECASE)
                    if m_id:
                        ev_id = m_id.group(1).upper()
                        if ev_id not in practice_tests_map:
                            practice_tests_map[ev_id] = []
                        rel_path = os.path.relpath(os.path.join(root, file), start='.')
                        url_path = rel_path.replace('\\\\', '/')
                        practice_tests_map[ev_id].append({
                            "name": file,
                            "url": url_path
                        })

    with open('events-db.js', 'r', encoding='utf-8') as f:
        content = f.read()

    new_content = content
    for ev_id in re.findall(r'\"id\":\s*\"([^\"]+)\"', content):
        tests = practice_tests_map.get(ev_id, [])
        tests_json = json.dumps(tests)
        
        pattern = r'(\"id\":\s*\"' + re.escape(ev_id) + r'\".*?)\"quizzes\":\s*\[\]'
        new_content = re.sub(pattern, r'\g<1>\"practiceTests\": ' + tests_json.replace('\\', '\\\\'), new_content, flags=re.DOTALL)
    
    with open('events-db.js', 'w', encoding='utf-8') as f:
        f.write(new_content)
    print("Updated events-db.js")

if __name__ == '__main__':
    main()
