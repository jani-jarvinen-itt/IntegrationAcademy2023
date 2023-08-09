import http.client
import json

host = "jsonplaceholder.typicode.com"
conn = http.client.HTTPSConnection(host)
conn.request("GET", "/users", headers={"Host": host})
response = conn.getresponse()

jsondata = response.read().decode()
käyttäjät = json.loads(jsondata)

for käyttäjä in käyttäjät:
    print(käyttäjä["name"], "-", käyttäjä["address"]["city"])
