import glob

for f in glob.glob('*.html'):
    try:
        with open(f, 'r', encoding='utf-8') as file:
            content = file.read()
    except UnicodeDecodeError:
        with open(f, 'r', encoding='utf-16') as file:
            content = file.read()
            
    original = content
    content = content.replace('<a href="#">Contact</a>', '')
    content = content.replace('<a href="contact.html">Contact</a>', '')
    
    if content != original:
        try:
            with open(f, 'w', encoding='utf-8') as file:
                file.write(content)
        except Exception:
            with open(f, 'w', encoding='utf-16') as file:
                file.write(content)
