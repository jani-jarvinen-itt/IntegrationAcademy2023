using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace WebApiTesti.Controllers;

[ApiController]
[Route("kokeilu")]
public class OmaTestiController : ControllerBase
{
    [Route("moi")]
    public string SanoMoi()
    {
        return "Moi maailma!";
    }

    [Route("aika")]
    public DateTime Kellonaika()
    {
        return DateTime.Now;
    }

    [Route("csvluku")]
    public List<Henkilö> LueCsvTiedosto()
    {
        string tiedostonimi = @"C:\Integration\Koodit\DotNet\WebApiTesti\Henkilöt.csv";
        string[] rivit = System.IO.File.ReadAllLines(tiedostonimi);

        List<Henkilö> tulokset = new();
        for (int i = 1; i < rivit.Length; i++)
        {
            string rivi = rivit[i];

            string[] osat = rivi.Split(';');
            Henkilö henkilö = new()
            {
                Nimi = osat[0],
                Kengännumero = int.Parse(osat[1])
            };
            tulokset.Add(henkilö);
        }

        return tulokset;
    }

    [Route("sqlluku")]
    public List<Asiakas> LueAsiakkaatSqlKannasta()
    {
        List<Asiakas> tulokset = new();

        string yhteysmerkkijono = "Server=localhost\\SQLEXPRESS;Database=Northwind;Trusted_Connection=true;Encrypt=no;";
        SqlConnection yhteys = new SqlConnection(yhteysmerkkijono);
        yhteys.Open();

        string sql = "SELECT CompanyName, ContactName, Country FROM Customers";
        SqlCommand komento = new(sql, yhteys);
        SqlDataReader lukija = komento.ExecuteReader();

        while (lukija.Read())
        {
            Asiakas asiakas = new()
            {
                YritysNimi = lukija["CompanyName"].ToString() ?? "",
                Yhteyshenkilö = lukija["ContactName"].ToString() ?? "",
                Maa = lukija["Country"].ToString() ?? ""
            };

            tulokset.Add(asiakas);
        }

        return tulokset;
    }
}
