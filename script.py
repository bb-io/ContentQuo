import json

with open('languages.json', encoding='utf-8') as fh:
  data = json.load(fh)

unique = set()
with open('output.txt', 'w', encoding='utf-8') as fh:
  for lang in sorted([x for x in data if x['show'] and x['fullcode'] not in unique and not unique.add(x['fullcode'])], key=lambda x: x['title']):
    fh.write(f"{{ \"{lang['fullcode']}\", \"{lang['title']}\" }},\n")