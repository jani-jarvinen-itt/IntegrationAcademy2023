using System.IO;
using Microsoft.AspNetCore.Mvc;

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
}
