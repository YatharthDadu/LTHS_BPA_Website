import pymupdf
import re
import json

doc = pymupdf.open("WSAP 2025-2026.pdf")
text = ""
for page in doc:
    text += page.get_text() + "\n"

# The events start around page 40 and end around page 280
# Let's find all events. An event header looks like "(V01) Virtual Multimedia and Promotion Individual"
# Or "(100) Fundamental Accounting"

events = {}

# Regex to find event headers
pattern = r'\(([A-Z0-9]{3})\)\s+(.*?)\n(.*?)(?=\n\([A-Z0-9]{3}\)\s+|$)'
# Wait, a better way is to split the text by "(XXX) "
parts = re.split(r'\n\(([A-Z0-9]{3})\)\s+', text)

for i in range(1, len(parts), 2):
    code = parts[i]
    content = parts[i+1]
    
    # Title is the first line
    title = content.split('\n')[0].strip()
    
    # Extract Description & Eligibility
    desc_match = re.search(r'Description & Eligibility\s*\n(.*?)(?=\n[A-Z][a-z]+)', content, re.DOTALL)
    description = ""
    if desc_match:
        description = desc_match.group(1).replace('\n', ' ').strip()
        # remove boilerplate like "This national event will be submitted..."
        description = re.sub(r'This national event will be submitted.*?\.', '', description)
        description = re.sub(r'Awards will be presented.*?\.', '', description)
        description = re.sub(r'Any middle level, secondary or postsecondary contestant.*?\.', '', description)
        description = re.sub(r'There are no restrictions on the number of entries.*?\.', '', description)
        description = re.sub(r'Contestants who do not submit.*?\.', '', description)
        description = re.sub(r'Teams who do not submit.*?\.', '', description)
        description = re.sub(r'Any postsecondary or secondary division contestant may enter.*?\.', '', description)
        description = re.sub(r'This application event is limited to secondary division.*?\.', '', description)
        description = re.sub(r'Contestants may not enter.*?\.', '', description)
        description = re.sub(r'This event may not be repeated.*?\.', '', description)
        description = re.sub(r'Entries that do not follow.*?\.', '', description)
        
        description = re.sub(r'\s+', ' ', description).strip()
        
    # Extract Topic
    topic_match = re.search(r'\nTopic\s*\n(.*?)(?=\n[A-Z][a-z]+)', content, re.DOTALL)
    topic = ""
    if topic_match:
        topic = topic_match.group(1).replace('\n', ' ').strip()
        topic = re.sub(r'\s+', ' ', topic).strip()
        
    # Combine them to form a robust 2-3 sentence description
    combined = []
    
    # Get sentences
    desc_sentences = re.split(r'(?<=[.!?])\s+', description)
    topic_sentences = re.split(r'(?<=[.!?])\s+', topic)
    
    # Clean up empty sentences
    desc_sentences = [s.strip() for s in desc_sentences if len(s.strip()) > 5]
    topic_sentences = [s.strip() for s in topic_sentences if len(s.strip()) > 5]
    
    final_desc = " ".join(desc_sentences[:3])
    if topic_sentences and len(desc_sentences) < 3:
        final_desc += " Topic: " + " ".join(topic_sentences[:2])
        
    if not final_desc:
        final_desc = "Detailed information for this event will be updated soon."
        
    events[code] = final_desc

# Write to JSON
with open('extracted_long_descriptions.json', 'w', encoding='utf-8') as f:
    json.dump(events, f, indent=4)
print(f"Extracted {len(events)} events.")
