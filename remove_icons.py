import glob
import re

for f in glob.glob('*.html'):
    try:
        with open(f, 'r', encoding='utf-8') as file:
            content = file.read()
    except Exception:
        with open(f, 'r', encoding='utf-16') as file:
            content = file.read()
            
    original = content
    
    # Remove search-icon div
    content = re.sub(r'<div class="icon-btn search-icon">[\s\S]*?</div>\s*<div class="icon-btn notif-icon">', '<div class="icon-btn notif-icon">', content)
    
    # Remove notif-icon div
    content = re.sub(r'<div class="icon-btn notif-icon">[\s\S]*?</div>', '', content)
    
    # Just in case search-icon was standalone
    content = re.sub(r'<div class="icon-btn search-icon">[\s\S]*?</div>', '', content)
    
    if content != original:
        try:
            with open(f, 'w', encoding='utf-8') as file:
                file.write(content)
        except Exception:
            with open(f, 'w', encoding='utf-16') as file:
                file.write(content)
