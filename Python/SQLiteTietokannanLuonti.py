import sqlite3

print("Aloitetaan SQLite-tietokannan käsittely.")
yhteys = sqlite3.connect("käyttäjät.db")
print("Tietokantayhteys avattu.")

kursori = yhteys.cursor()
kursori.execute("CREATE TABLE käyttäjät(nimi, kaupunki, puhelin)")
print("Tietokantataulu luotu.")
