from flask import Flask, request

app = Flask(__name__)

@app.route("/")
def hello():
    return "Moi maailma Integraatio-koulutusohjelmasta!"

@app.route("/api/luvut")
def luvut():
    return [1, 2, 3]

@app.route("/api/parametrit", methods=["GET", "POST", "PUT"])
def parametrit():
    metodi = request.method
    return f"Tämä pyyntö tehtiin HTTP:n {metodi}-metodilla."



@app.route("/api/asiakkaat")
def hae_kaikki_asiakkaat():
    tiedosto = open("..\\Esimerkki.csv", "r", encoding="utf8")
    asiakkaat = []
    rivit = tiedosto.readlines()
    for rivi in rivit:
        osat = rivi.split(";")
        asiakas = {
            "asiakasId": osat[0],
            "nimi": osat[1],
            "osoite": osat[2]
        }
        asiakkaat.append(asiakas)
    tiedosto.close()
    return asiakkaat


@app.route("/api/asiakkaat/<int:asiakasid>")
def hae_asiakas_idnumeron_perusteella(asiakasid):
    tiedosto = open("..\\Esimerkki.csv", "r", encoding="utf8")
    rivit = tiedosto.readlines()
    asiakas = {}
    for rivi in rivit:
        osat = rivi.split(";")
        if int(osat[0]) == asiakasid:
            asiakas = {
                "asiakasId": osat[0],
                "nimi": osat[1],
                "osoite": osat[2]
            }
    tiedosto.close()
    return asiakas

@app.route("/api/asiakas/<int:asiakasid>")
def hae_asiakas(asiakasid):
    return f"Tässä asiakkaan {asiakasid} tiedot..."

@app.route("/api/kyselyparametrit")
def kyselyparametrit():
    arvo = request.args.get("asiakasid")
    return f"Asiakas-id:n arvo on: " + str(arvo)

@app.route("/api/haku", methods=["POST"])
def haku():
    hakuehdot = request.json
    print(hakuehdot)
    return "Hakuehdot olivat: " + str(hakuehdot)
