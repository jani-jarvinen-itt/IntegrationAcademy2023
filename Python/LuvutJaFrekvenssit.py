luvut = []

while True:
    syöte = input("Syötä luku 1-99 tai nolla lopettaaksesi: ")
    if syöte == "0":
        break
    luvut.append(int(syöte))

print("Luvut syötetty.")
luvut.sort()

print("Luvut numerojärjestyksessä:")
for luku in luvut:
    print(luku)
