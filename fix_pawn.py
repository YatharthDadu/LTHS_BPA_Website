import glob

svg_icon = '''<a href="login.html" class="icon-btn profile-icon" aria-label="Officer login">
                    <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                        <path d="M 2 9 L 12 4 L 22 9 L 12 14 Z" />
                        <path d="M 6 11 V 16 C 6 19, 18 19, 18 16 V 11" />
                        <path d="M 13 9.5 L 21 9.5 V 15.5" />
                        <circle cx="21" cy="17" r="1.5" />
                        <path d="M 20 18.2 L 19 22.5 C 20 23.5, 22 23.5, 23 22.5 L 22 18.2" />
                    </svg>
                </a>'''

for f in glob.glob('*.html'):
    try:
        with open(f, 'r', encoding='utf-8') as file:
            content = file.read()
    except Exception:
        with open(f, 'r', encoding='utf-16') as file:
            content = file.read()
            
    original = content
    content = content.replace('<a href="login.html" class="icon-btn profile-icon" aria-label="Officer login">♙</a>', svg_icon)
    content = content.replace('<a href="login.html" class="icon-btn profile-icon">♙</a>', svg_icon)
    
    if content != original:
        try:
            with open(f, 'w', encoding='utf-8') as file:
                file.write(content)
        except Exception:
            with open(f, 'w', encoding='utf-16') as file:
                file.write(content)
