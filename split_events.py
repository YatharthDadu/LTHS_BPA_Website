import fitz
import re
import os
import json

if not os.path.exists('pdfs'):
    os.makedirs('pdfs')

doc = fitz.open('WSAP 2025-2026.pdf')

toc_text = ""
for i in range(1, 5):
    toc_text += doc[i].get_text()

# Extract event logical pages
# e.g., (100) Fundamental Accounting ..................................... 113
event_starts = {}
pattern = re.compile(r'\((V\d{2}|\d{3})\)\s+(.*?)\.*?\s+(\d+)\s*\n')
matches = pattern.findall(toc_text)
for match in matches:
    event_id = match[0]
    logical_page = int(match[2])
    physical_page = logical_page + 4
    event_starts[event_id] = physical_page

# Sort by physical page to find endpoints
sorted_events = sorted(event_starts.items(), key=lambda x: x[1])

print(f"Found {len(sorted_events)} events.")
for i in range(len(sorted_events)):
    event_id, start_page = sorted_events[i]
    if i < len(sorted_events) - 1:
        end_page = sorted_events[i+1][1] - 1
    else:
        end_page = len(doc) - 1
        
    out_pdf = fitz.open()
    out_pdf.insert_pdf(doc, from_page=start_page, to_page=end_page)
    out_pdf.save(f"pdfs/event_{event_id}.pdf")
    out_pdf.close()

print("Created all PDFs.")
