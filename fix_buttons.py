import io
with io.open('competitions.html', 'r', encoding='utf-8') as f:
    content = f.read()

old_str = '<span class="guidelines-pill">WSAP Guidelines</span>'
new_str = '<button class="guidelines-pill" onclick="window.open(''WSAP%202025-2026.pdf'', ''_blank''); event.stopPropagation();" style="cursor: pointer; border: none; font-family: inherit;">25-26 WSAP document</button>'

new_content = content.replace(old_str, new_str)

with io.open('competitions.html', 'w', encoding='utf-8') as f:
    f.write(new_content)

print(f'Replaced {content.count(old_str)} occurrences.')
