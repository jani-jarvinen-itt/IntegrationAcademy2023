luvut = []
frekvenssit = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

while True:
    syöte = input("Syötä luku 1-99 tai nolla lopettaaksesi: ")
    if syöte == "0":
        break
    luvut.append(int(syöte))

    lukualue = int(syöte) // 10
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
