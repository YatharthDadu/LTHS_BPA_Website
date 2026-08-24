import re

js_file_path = r"c:\Users\Owner\Downloads\NewBPAWebsite\events-db.js"

with open(js_file_path, "r", encoding="utf-8") as f:
    js_content = f.read()

# Fix double quotes: description: ""Text"" -> description: "Text"
fixed_js_content = re.sub(r'description:\s*""(.*?)"",', r'description: "\1",', js_content)

with open(js_file_path, "w", encoding="utf-8") as f:
    f.write(fixed_js_content)

print("Fixed double quotes in events-db.js")
