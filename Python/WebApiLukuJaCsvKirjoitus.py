import http.client
import json

# vaihe 1, Web API -palvelun kutsuminen
host = "webapitest.intertechno.org:4000"
conn = http.client.HTTPSConnection(host)
conn.request("GET", "/api/NorthwindCustomers", headers={"Host": host})
response = conn.getresponse()

# vaihe 2, JSON-datan muunnos olioksi
jsondata = response.read().decode()
asiakkaat = json.loads(jsondata)
# print(asiakkaat)

# vaihe 3, asiakkaiden läpikäynti
csv = "AsiakasId;YritysNimi;Kontaktihenkilö;Maa\n"
for asiakas in asiakkaat:
    maa = asiakas["country"]
    if maa == "Finland":
        id = asiakas["customerId"]
        nimi = asiakas["companyName"]
        kontakti = asiakas["contactName"]
        print(nimi)
        csv = csv + f"{id};{nimi};{kontakti};{maa}\n"

print("---------")
print(csv)
print("---------")

# vaihe 4, CSV:n kirjoitus tiedostoon
tiedostonimi = "Northwind-asiakkaat.csv"
tiedosto = open(tiedostonimi, "w", encoding="utf8")
tiedosto.write(csv)
tiedosto.close()

print("CSV-tiedosto kirjoitettu.")
