import re

with open('events-db.js', 'r', encoding='utf-8') as f:
    content = f.read()

# Fix backslash URLs - in JSON string values inside "url": "...", convert \\ to /
# The double backslash in the file represents a single backslash in actual path

def fix_url(m):
    url = m.group(1)
    url_fixed = url.replace('\\\\', '/').replace('\\', '/')
    return '"url": "' + url_fixed + '"'

new_content = re.sub(r'"url": "([^"]*)"', fix_url, content)

if new_content != content:
    changed = content.count('\\\\')
    print(f'Fixed {changed} backslash occurrences')
    with open('events-db.js', 'w', encoding='utf-8') as f:
        f.write(new_content)
    print('Saved.')
else:
    print('No backslashes found - content unchanged.')
