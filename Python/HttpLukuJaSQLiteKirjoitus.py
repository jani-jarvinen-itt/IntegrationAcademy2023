import http.client
import json
import sqlite3

# vaihe 1, JSONPlaceholder-palvelun API:n kutsuminen
host = "jsonplaceholder.typicode.com"
conn = http.client.HTTPSConnection(host)
conn.request("GET", "/users", headers={"Host": host})
response = conn.getresponse()

jsondata = response.read().decode()
käyttäjät = json.loads(jsondata)

# SQLite-tietokannan käsittely
print("Aloitetaan SQLite-tietokannan käsittely.")
yhteys = sqlite3.connect("käyttäjät.db")
print("Tietokantayhteys avattu.")
kursori = yhteys.cursor()

# vaihe 2, tallennus SQLite-tietokantaan
for käyttäjä in käyttäjät:
    nimi = käyttäjä["name"]
    kaupunki = käyttäjä["address"]["city"]
    puhelin = käyttäjä["phone"]
    
    # Varoitus! Seuraava rivi on SQL Injection -hyökkäykselle altis!
    kursori.execute("INSERT INTO käyttäjät VALUES ('"+nimi+"', '"+kaupunki+"', '"+puhelin+"')")
    print("Lisätty käyttäjä:", nimi)

print("Tallennetaan muutokset tietokantaan.")
yhteys.commit()

print("Käyttäjätaulun rivimäärä:")
tulokset = kursori.execute("SELECT COUNT(*) FROM käyttäjät")
käyttäjällkm = tulokset.fetchall()
print(käyttäjällkm)

print("Suoritus päättyy.")
