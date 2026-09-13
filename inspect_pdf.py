import fitz
doc = fitz.open('WSAP 2025-2026.pdf')
found = False
for i in range(10, len(doc)):
    page = doc[i]
    text = page.get_text()
    if 'Fundamental Accounting' in text and '(100)' in text:
        print(f"--- PAGE {i} ---")
        print(text[:300])
        found = True
        break
if not found:
    for i in range(10, len(doc)):
        page = doc[i]
        text = page.get_text()
        if 'Fundamental Accounting' in text and '100' in text:
            print(f"--- PAGE {i} ---")
            print(text[:300])
            break
