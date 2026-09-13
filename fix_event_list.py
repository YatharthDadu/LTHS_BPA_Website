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

categories = {
    '1': 'finance',
    '2': 'business',
    '3': 'mis',
    '4': 'digital',
    '5': 'management',
    '6': 'health'
}

cat_events = {v: [] for v in categories.values()}
for ev in user_events:
    prefix = ev['id'][0]
    if prefix in categories:
        cat_events[categories[prefix]].append(ev)

default_icon = '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-calculator"><rect width="16" height="20" x="4" y="2" rx="2"/><line x1="8" x2="16" y1="6" y2="6"/><line x1="16" x2="16" y1="14" y2="18"/><path d="M16 10h.01"/><path d="M12 10h.01"/><path d="M8 10h.01"/><path d="M12 14h.01"/><path d="M8 14h.01"/><path d="M12 18h.01"/><path d="M8 18h.01"/></svg>'

for cat_id, events in cat_events.items():
    if not events: continue
    
    new_grid_html = ''
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
        new_grid_html += ticket

    # We want to replace the contents inside <div class="events-grid"> for this category
    start_str = f'<article id="{cat_id}"'
    start_idx = html.find(start_str)
    if start_idx == -1:
        print(f"Failed to find {start_str}")
        continue
    
    grid_start_idx = html.find('<div class="events-grid">', start_idx) + len('<div class="events-grid">')
    article_end_idx = html.find('</article>', grid_start_idx)
    
    # We need to find the last </div> before </article>
    sub_html = html[grid_start_idx:article_end_idx]
    last_div_idx = sub_html.rfind('</div>')
    
    grid_end_idx = grid_start_idx + last_div_idx
    
    html = html[:grid_start_idx] + '\n' + new_grid_html + '          ' + html[grid_end_idx:]

with open('competitions.html', 'w', encoding='utf-8') as f:
    f.write(html)

print("Updated HTML strictly!")
