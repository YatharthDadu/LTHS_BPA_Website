import json
import re

# Parse user events
user_events = []
with open('user_events.txt', 'r', encoding='windows-1252') as f:
    for line in f:
        line = line.strip()
        if not line: continue
        m = re.match(r'\(?(\d{3})\)?\s+(.*)', line)
        if m:
            title = m.group(2).strip()
            user_events.append({'id': m.group(1), 'title': title})

with open('competitions.html', 'r', encoding='utf-8') as f:
    html = f.read()

existing_desc = {}
existing_icons = {}
ticket_pattern = re.compile(r'<span class="ticket-serial">(\d{3})</span>.*?<div class="event-icon">(.*?)</div>.*?<h3>.*?</h3>.*?<p class="ticket-mini-desc"[^>]*>(.*?)</p>', re.DOTALL)
for m in ticket_pattern.finditer(html):
    eid = m.group(1)
    icon = m.group(2)
    desc = m.group(3)
    existing_desc[eid] = desc
    existing_icons[eid] = icon

categories = [
    {'id': 'finance', 'title': 'Finance'},
    {'id': 'business', 'title': 'Business Administration'},
    {'id': 'mis', 'title': 'Management Information Systems'},
    {'id': 'digital', 'title': 'Digital Communication and Design'},
    {'id': 'management', 'title': 'Management, Marketing and Communication'},
    {'id': 'health', 'title': 'Health Administration'}
]

cat_events = {c['id']: [] for c in categories}
for ev in user_events:
    prefix = int(ev['id'][0]) - 1
    if 0 <= prefix < len(categories):
        cat_events[categories[prefix]['id']].append(ev)

default_icon = '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-calculator"><rect width="16" height="20" x="4" y="2" rx="2"/><line x1="8" x2="16" y1="6" y2="6"/><line x1="16" x2="16" y1="14" y2="18"/><path d="M16 10h.01"/><path d="M12 10h.01"/><path d="M8 10h.01"/><path d="M12 14h.01"/><path d="M8 14h.01"/><path d="M12 18h.01"/><path d="M8 18h.01"/></svg>'

new_html_content = ""

for cat in categories:
    cat_id = cat['id']
    events = cat_events[cat_id]
    if not events: continue
    
    active_cls = " active" if cat_id == "finance" else ""
    display_style = "" if cat_id == "finance" else ' style="display: none;"'
    
    new_html_content += f'      <article id="{cat_id}" class="category-section{active_cls}"{display_style}>\n          <div class="ticket-grid">\n'
    for ev in events:
        eid = ev['id']
        title = ev['title']
        desc = existing_desc.get(eid, "Description coming soon.")
        icon = existing_icons.get(eid, default_icon)
        
        ticket = f'''              <!-- Event {eid} -->
              <a href="#" class="event-ticket">
                  <div class="ticket-stub">
                      <span class="ticket-serial">{eid}</span>
                      <div class="ticket-zig-zag"></div>
                  </div>
                  <div class="ticket-main">
                      <div class="ticket-content">
                          <div class="event-icon">{icon}</div>
                          <h3>{title}</h3>
                          <p class="ticket-mini-desc" style="font-size: 0.85rem; color: var(--text-muted); margin-top: 0.5rem; line-height: 1.4;">{desc}</p>
                      </div>
                      <div class="ticket-footer">
                          <button class="guidelines-pill" onclick="window.open('pdfs/event_{eid}.pdf', '_blank'); event.stopPropagation();" style="cursor: pointer; border: none; font-family: inherit;">25-26 WSAP document</button>
                      </div>
                  </div>
              </a>
'''
        new_html_content += ticket
    new_html_content += '          </div>\n      </article>\n'

# Find where to replace
# From <article id="finance" class="category-section active"> 
# to the end of the last article <article id="virtual"...</article>
start_idx = html.find('<article id="finance"')
end_idx = html.find('<!-- Modal -->')

if start_idx != -1 and end_idx != -1:
    # Look back a bit to see what we are replacing.
    # The new html_content will replace everything between start_idx and end_idx.
    
    # Let's remove the virtual switch tab
    html = re.sub(r'<a class="switch-tab" href="#virtual">900: Virtual</a>', '', html)
    
    # We should keep the closing divs if they are between end of articles and modal
    # In original html, there are 3 closing divs between the last article and the modal.
    html_before = html[:start_idx]
    
    # Let's find exactly the last closing article
    articles_end = html.rfind('</article>', start_idx, end_idx) + 10
    
    html = html_before + new_html_content + html[articles_end:]

with open('competitions.html', 'w', encoding='utf-8') as f:
    f.write(html)

print("Generated new HTML correctly.")
