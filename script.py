import json

with open('languages.json', encoding='utf-8') as fh:
  data = json.load(fh)

with open('output.txt', 'w', encoding='utf-8') as fh:
  for lang in sorted([x for x in  data if x['show']], key=lambda x: x['title']):
    fh.write(f"{{ \"{lang['fullcode']}\", \"{lang['title']}\" }},\n")