luvut = []
frekvenssit = [0] * 10

def lue_luku():
    while True:
        syöte = input("Syötä luku 1-99 tai nolla lopettaaksesi: ")
        try:
            luku = int(syöte)
            return luku
        except:
            print("Luvun on oltava välillä 1-99, yritä uudelleen.")

while True:
    syöte = lue_luku()
    if syöte == 0:
        break
    luvut.append(syöte)
    print("Luku tallennettu, syötä uusi luku.")

    lukualue = syöte // 10
    frekvenssit[lukualue] += 1

print("Luvut syötetty.")
luvut.sort()

print("Luvut numerojärjestyksessä:")
for luku in luvut:
    print(luku)

print("Frekvenssit:")
for määrä in frekvenssit:
    print(määrä)

print("Loppu.")
