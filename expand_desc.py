import json
import re

html_file_path = r"c:\Users\Owner\Downloads\NewBPAWebsite\competitions.html"
js_file_path = r"c:\Users\Owner\Downloads\NewBPAWebsite\events-db.js"

# 1. First, parse events-db.js to get all current events
with open(js_file_path, "r", encoding="utf-8") as f:
    js_content = f.read()

# We'll extract the JSON part from events-db.js
json_match = re.search(r'window\.bpaEvents\s*=\s*(\{.*?\});', js_content, re.DOTALL)
if not json_match:
    print("Could not find window.bpaEvents in events-db.js")
    exit()

# It's a JS object, not strict JSON. Let's fix the keys so we can parse it as JSON
js_obj_str = json_match.group(1)
js_obj_str = re.sub(r'(\w+):\s+', r'"\1": ', js_obj_str)
js_obj_str = re.sub(r'"http(.*?)"', r'http\1', js_obj_str) # Quick hack for URLs if needed
try:
    events = json.loads(js_obj_str)
except Exception as e:
    print("Error parsing JS object to JSON. Proceeding with string manipulation.")
    events = None

def expand_description(event_id, short_desc):
    # Capitalize first letter and fix imperative verbs
    if not short_desc:
        short_desc = "Demonstrate proficiency in this competitive event."
    
    first_word = short_desc.split(' ')[0]
    imperatives = ["Assess", "Create", "Develop", "Demonstrate", "Analyze", "Evaluate", "Perform", "Utilize", "Research", "Apply", "Design", "Process", "Focus"]
    
    clean_desc = short_desc
    if first_word in imperatives:
        clean_desc = "Participants will " + short_desc[0].lower() + short_desc[1:]
    elif short_desc.startswith("This event evaluates"):
        pass # leave alone
    else:
        # Just prepend something generic if it doesn't fit
        pass

    if event_id.startswith('1'):
        prefix = "This event evaluates a contestant's understanding of key financial concepts and practices."
        suffix = "Competitors will demonstrate their ability to apply these principles to real-world scenarios, showcasing their analytical and quantitative skills."
    elif event_id.startswith('2'):
        prefix = "This event focuses on essential administrative and organizational skills required in today's modern business environment."
        suffix = "Participants will showcase their technical proficiency, attention to detail, and ability to manage critical business operations."
    elif event_id.startswith('3'):
        prefix = "This event challenges students to demonstrate their technical expertise in managing and securing information systems."
        suffix = "Competitors will apply their knowledge to solve complex IT problems and implement effective technological solutions."
    elif event_id.startswith('4'):
        prefix = "This event highlights creativity, design principles, and effective digital communication."
        suffix = "Participants will utilize industry-standard tools to produce high-quality media that effectively engages and informs target audiences."
    elif event_id.startswith('5'):
        prefix = "This event emphasizes leadership, strategic planning, and effective marketing techniques."
        suffix = "Teams and individuals will demonstrate their ability to communicate persuasively, solve management challenges, and develop comprehensive business strategies."
    elif event_id.startswith('6'):
        prefix = "This event evaluates specialized skills required for success in the healthcare administration field."
        suffix = "Participants will demonstrate their understanding of medical terminology, procedures, and ethical practices within a clinical setting."
    elif event_id.startswith('V'):
        prefix = "This virtual event challenges participants to leverage digital tools and remote collaboration."
        suffix = "Competitors will showcase their adaptability, technical skills, and innovative thinking in a fully online competitive environment."
    else:
        prefix = "This competitive event tests participants on their foundational knowledge and application of business skills."
        suffix = "Competitors will demonstrate their dedication to professional growth and technical excellence."

    # If the short description already sounds like the prefix, avoid redundancy
    if "evaluates" in clean_desc and "evaluates" in prefix:
        prefix = "This competition provides an excellent opportunity to showcase specialized business acumen."

    expanded = f"{prefix} {clean_desc} {suffix}"
    
    # Fix double spaces or weird punctuation
    expanded = expanded.replace("..", ".").replace("  ", " ")
    
    return expanded

# Read the HTML
with open(html_file_path, "r", encoding="utf-8") as f:
    html_content = f.read()

# We will search for all ticket descriptions in the HTML and expand them!
# Pattern: <span class="ticket-serial">100</span> ... <p class="ticket-mini-desc" ...>Assess entry-level...</p>
def replace_html_desc(match):
    prefix1 = match.group(1)
    event_id = match.group(2)
    prefix2 = match.group(3)
    short_desc = match.group(4)
    suffix = match.group(5)
    
    new_desc = expand_description(event_id, short_desc)
    
    return f"{prefix1}{event_id}{prefix2}{new_desc}{suffix}"

new_html_content = re.sub(r'(<span class="ticket-serial">)(.*?)(</span>.*?<p class="ticket-mini-desc"[^>]*>)(.*?)(</p>)', replace_html_desc, html_content, flags=re.DOTALL)

with open(html_file_path, "w", encoding="utf-8") as f:
    f.write(new_html_content)


# We ALSO need to update events-db.js
def replace_js_desc(match):
    prefix = match.group(1)
    event_id = match.group(2)
    middle = match.group(3)
    short_desc = match.group(4)
    suffix = match.group(5)
    
    new_desc = expand_description(event_id, short_desc)
    
    return f'{prefix}{event_id}{middle}"{new_desc}"{suffix}'

new_js_content = re.sub(r'(id:\s*")([^"]+)(".*?description:\s*")(.*?)(")', replace_js_desc, js_content, flags=re.DOTALL)

with open(js_file_path, "w", encoding="utf-8") as f:
    f.write(new_js_content)

print("Successfully updated both HTML and JS with expanded descriptions!")
