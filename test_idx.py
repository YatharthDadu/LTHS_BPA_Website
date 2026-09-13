with open('competitions.html', 'r', encoding='utf-8') as f: html = f.read()
print('start:', html.find('<article id="finance"'))
print('end:', html.find('<!-- Modal -->'))
