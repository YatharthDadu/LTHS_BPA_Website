import re

# Mapping of names to image files
# Note: Victoria corresponds to Vicky
images_map = {
    "Shivanshi": "images/shivanshi.jpg",
    "Vaishavi": "images/vaishavi.jpg",
    "Anuraag": "images/anuraag.jpg",
    "Oviya": "images/oviya.jpg",
    "Vicky": "images/victoria.jpg"
}

with open("officers.html", "r", encoding="utf-8") as f:
    content = f.read()

# We need to find each officer block and update the placeholder if we have an image
# An officer block looks like:
# <div class="officer-img-area bg-pastel-blue">
#     <div class="officer-blob" style="border-radius: 40% 60% 70% 30% / 40% 50% 60% 50%;"></div>
#     <div class="officer-placeholder">👤</div>
# </div>
# <div class="officer-info">
#     <div class="officer-header">
#         <h4>Shivanshi</h4>

blocks = re.split(r'(<div class="officer-card neu-shadow">)', content)

new_content = blocks[0]
for i in range(1, len(blocks), 2):
    card_start = blocks[i]
    card_content = blocks[i+1]
    
    # Extract the name from <h4>Name</h4>
    name_match = re.search(r'<h4>(.*?)</h4>', card_content)
    if name_match:
        name = name_match.group(1).strip()
        if name in images_map:
            img_path = images_map[name]
            
            # Extract the border-radius from the blob
            blob_match = re.search(r'<div class="officer-blob" style="(.*?)"></div>', card_content)
            border_radius_style = blob_match.group(1) if blob_match else ""
            
            # Replace placeholder with img tag
            img_tag = f'<img src="{img_path}" class="officer-photo" style="{border_radius_style}" alt="{name}">'
            card_content = re.sub(r'<div class="officer-placeholder">.*?</div>', img_tag, card_content, flags=re.DOTALL)
            
            # Hide the original blob since the image is now the blob, or keep the blob behind the image?
            # Let's keep the blob slightly shifted for a cool effect, but we need to remove the inline border radius from the image or use it.
            # If we apply border-radius to the image, it looks like a blob.
            
    new_content += card_start + card_content

with open("officers.html", "w", encoding="utf-8") as f:
    f.write(new_content)

print("officers.html updated")
