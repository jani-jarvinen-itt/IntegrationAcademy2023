rivit = []

while True:
    csv_rivi = input("Syötä CSV-rivi, tai tyhjä lopettaaksesi: ")
    if csv_rivi == "":
        break
    rivit.append(csv_rivi)

# print("----------")
# print(rivit)
# print("----------")

nimi_tiedot = { }
for rivi in rivit:
    välilyönti = rivi.index(" ")
    puolipiste = rivi.index(";", välilyönti + 1)
    # print(välilyönti, puolipiste)
    sukunimi = rivi[välilyönti+1:puolipiste]
    # print(sukunimi)

    if sukunimi in nimi_tiedot:
        nimi_tiedot[sukunimi].append(rivi)
    else:
        nimi_tiedot[sukunimi] = [rivi]

# print(nimi_tiedot)
sukunimi_lista = list(nimi_tiedot.keys())
sukunimi_lista.sort()

for sukunimi in sukunimi_lista:
    csv_rivit = nimi_tiedot[sukunimi]
    csv_rivit.sort()
    print(csv_rivit)
