import re

def update_profile_icon(filepath):
    with open(filepath, 'r', encoding='utf-8') as f:
        content = f.read()

    # Find the block: <div class="icon-btn profile-icon"> ... </div>
    # and replace with <a href="login.html" ...> ... </a>
    # Note: we already replaced the opening div in index.html, but the closing div is still there.
    # Let's write a targeted regex that looks for the SVG path inside the profile icon.

    pattern = r'(<a href="login\.html" class="icon-btn profile-icon">|<div class="icon-btn profile-icon">)(\s*<svg.*?</svg>\s*)</div>'
    replacement = r'<a href="login.html" class="icon-btn profile-icon">\2</a>'
    
    new_content = re.sub(pattern, replacement, content, flags=re.DOTALL)
    
    with open(filepath, 'w', encoding='utf-8') as f:
        f.write(new_content)
    print(f"Updated {filepath}")

update_profile_icon('index.html')
try:
    update_profile_icon('officers.html')
except FileNotFoundError:
    print("officers.html not found, skipping")
