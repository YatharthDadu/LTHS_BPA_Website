import json

transcript_path = r'C:\Users\Owner\.gemini\antigravity\brain\d74502e4-bd71-4e0f-8295-a7e8d93156e6\.system_generated\logs\transcript_full.jsonl'

text_found = False
with open(transcript_path, 'r', encoding='utf-8') as f:
    for line in f:
        if '==Start of OCR for page 45==' in line:
            try:
                data = json.loads(line)
                if 'output' in data.get('response', {}):
                    text = data['response']['output']
                    text_found = True
                    break
                elif 'output' in data:
                    text = data['output']
                    text_found = True
                    break
            except Exception as e:
                print("Error parsing JSON:", e)

if text_found:
    with open('full_ocr.txt', 'w', encoding='utf-8') as f:
        f.write(text)
    print("Successfully wrote full OCR to full_ocr.txt")
else:
    print("Could not find the OCR text in the transcript.")
