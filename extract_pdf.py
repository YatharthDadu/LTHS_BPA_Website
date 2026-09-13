import fitz
import re
import json

doc = fitz.open('WSAP 2025-2026.pdf')

# load event codes
event_codes = []
with open('event_descriptions.md', 'r') as f:
    for line in f:
        m = re.search(r'\*\s+\*\*\((.*?)\)', line)
        if m:
            event_codes.append(m.group(1).strip())

print(f"Found {len(event_codes)} event codes to look for.")

page_map = {}
current_event = None

for i in range(len(doc)):
    page = doc[i]
    text = page.get_text()
    
    # Check if this page is the start of a new event
    # Usually it says something like "(100) Fundamental Accounting" or just "100 Fundamental Accounting"
    # or "Fundamental Accounting (100)"
    
    found_event = None
    for code in event_codes:
        # Simple heuristic: if the code is isolated at the top of the page, or the exact string matches
        # Let's just do a regex search for the code in parentheses or isolated
        if f"({code})" in text or f"{code} " in text[:200]:
            found_event = code
            break
            
    if found_event:
        current_event = found_event
        if current_event not in page_map:
            page_map[current_event] = []
            
    if current_event:
        page_map[current_event].append(i)

for k, v in list(page_map.items())[:10]:
    print(f"Event {k}: Pages {v[0]} to {v[-1]}")

