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

@app.route("/api/asiakas/<int:asiakasid>")
def hae_asiakas(asiakasid):
    return f"Tässä asiakkaan {asiakasid} tiedot..."

@app.route("/api/kyselyparametrit")
def kyselyparametrit():
    arvo = request.args.get("asiakasid")
    return f"Asiakas-id:n arvo on: " + str(arvo)
