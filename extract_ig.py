import urllib.request
import re

req = urllib.request.Request('https://www.instagram.com/p/DZM5xOJkddy/', headers={'User-Agent': 'Mozilla/5.0'})
try:
    html = urllib.request.urlopen(req).read().decode('utf-8')
    images = set(re.findall(r'https://scontent[^\s\"\'\\]+\.jpg', html))
    print(f"Found {len(images)} images")
    for img in images:
        print(img)
except Exception as e:
    print(e)
