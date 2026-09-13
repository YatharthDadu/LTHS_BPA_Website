import io
with io.open('competitions.html', 'r', encoding='utf-8') as f:
    content = f.read()

old_str = '''        <!-- WSAP Guidelines -->
        <div class="modal-card card-wsap">
          <h3>WSAP Guidelines</h3>
          <p>Official rules, scoring rubrics, and detailed event requirements.</p>
          <a href="WSAP 2025-2026.pdf" target="_blank" class="retro-btn btn-wsap">25-26 WSAP document</a>
        </div>'''

new_str = '''        <!-- WSAP Guidelines 25-26 -->
        <div class="modal-card card-wsap">
          <h3>25-26 WSAP Documents</h3>
          <p>Official rules, scoring rubrics, and detailed event requirements.</p>
          <a href="WSAP 2025-2026.pdf" target="_blank" class="retro-btn btn-wsap">View 25-26 PDF</a>
        </div>

        <!-- WSAP Guidelines 26-27 -->
        <div class="modal-card card-wsap" style="background-color: var(--pastel-blue); border-color: var(--text-main);">
          <h3 style="color: var(--text-main);">26-27 WSAP Documents</h3>
          <p style="color: var(--text-main);">Updated rules and event requirements.</p>
          <a href="#" class="retro-btn btn-wsap" style="background-color: var(--text-muted); color: var(--white); cursor: not-allowed;" onclick="event.preventDefault();">In Progress</a>
        </div>'''

new_content = content.replace(old_str, new_str)

with io.open('competitions.html', 'w', encoding='utf-8') as f:
    f.write(new_content)

print("Done")
