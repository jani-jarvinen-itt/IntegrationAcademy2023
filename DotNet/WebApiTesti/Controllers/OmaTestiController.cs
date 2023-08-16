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
    public string LueCsvTiedosto()
    {
        string tiedostonimi = @"C:\Integration\Koodit\DotNet\WebApiTesti\Henkilöt.csv";
        string csv = System.IO.File.ReadAllText(tiedostonimi);

        return csv;
    }
}
