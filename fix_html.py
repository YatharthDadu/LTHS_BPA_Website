import re

html_file_path = r"c:\Users\Owner\Downloads\NewBPAWebsite\competitions.html"

with open(html_file_path, "r", encoding="utf-8") as f:
    html_content = f.read()

# Fix the <p> tag inside <h3> tag
# Find: <p class="ticket-mini-desc"(.*?)</p></h3>
# Replace with: </h3>\n                          <p class="ticket-mini-desc"\1</p>

fixed_html_content = re.sub(r'(<p class="ticket-mini-desc".*?</p>)</h3>', r'</h3>\n                          \1', html_content, flags=re.DOTALL)

with open(html_file_path, "w", encoding="utf-8") as f:
    f.write(fixed_html_content)

print("Fixed HTML formatting.")
