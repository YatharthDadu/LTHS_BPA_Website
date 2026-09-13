with open('index.html', 'r', encoding='utf-8') as f:
    html = f.read()

import re
html = re.sub(r'<div class="card-center-profile">.*?</div>\n\s*', '', html, flags=re.DOTALL)

with open('index.html', 'w', encoding='utf-8') as f:
    f.write(html)
print('Removed teacher icon div.')
