import json
import re
import os

md_file_path = r"C:\Users\Owner\.gemini\antigravity\brain\d74502e4-bd71-4e0f-8295-a7e8d93156e6\event_descriptions.md"
html_file_path = r"c:\Users\Owner\Downloads\NewBPAWebsite\competitions.html"

# Read descriptions
with open(md_file_path, "r", encoding="utf-8") as f:
    content = f.read()

events = {}
for line in content.split('\n'):
    line = line.strip()
    if line.startswith('* **'):
        m = re.match(r'\*\s+\*\*\((.*?)\)\s+(.*?):\*\*\s+(.*)', line)
        if m:
            event_code = m.group(1).strip()
            description = m.group(3).strip()
            events[event_code] = description

# Modify HTML
with open(html_file_path, "r", encoding="utf-8") as f:
    html_content = f.read()

# We need to find each ticket, extract its ID, and inject the description.
# A ticket looks like:
# <span class="ticket-serial">100</span>
# ...
# <h3>Fundamental Accounting</h3>
# We can use regex to find this block and insert the <p>.

def replace_ticket(match):
    prefix = match.group(1)
    event_id = match.group(2)
    middle = match.group(3)
    h3_content = match.group(4)
    suffix = match.group(5)
    
    desc = events.get(event_id, "Description coming soon.")
    
    # Check if a description already exists to avoid duplicating
    if '<p class="ticket-mini-desc"' in middle or '<p class="ticket-mini-desc"' in suffix:
        return match.group(0)
    
    # We will inject the description right after the </h3> tag.
    new_suffix = f'\n                          <p class="ticket-mini-desc" style="font-size: 0.85rem; color: var(--text-muted); margin-top: 0.5rem; line-height: 1.4;">{desc}</p>{suffix}'
    
    return f'{prefix}{event_id}{middle}{h3_content}{new_suffix}'

# Regex to match the ticket block
pattern = r'(<span class="ticket-serial">)(.*?)(</span>.*?<h3>)(.*?)(</h3>)'

new_html_content = re.sub(pattern, replace_ticket, html_content, flags=re.DOTALL)

with open(html_file_path, "w", encoding="utf-8") as f:
    f.write(new_html_content)

print(f"Updated competitions.html with event descriptions.")
