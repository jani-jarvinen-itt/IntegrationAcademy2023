using EntityFrameworkWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EntityFrameworkWebApi.Controllers;

[ApiController]
[Route("/api/asiakkaat")]
public class AsiakkaatApiController : ControllerBase
{
    [HttpGet]
    public List<Customer> HaeKaikkiAsiakkaat()
    {
        NorthwindContext konteksti = new();
        List<Customer> asiakkaat = konteksti.Customers.ToList();
        return asiakkaat;
    }

    [HttpGet]
    [Route("maa/{maa}")]
    public List<Customer> HaeAsiakkaatMaittain(string maa)
    {
        /*
        // suora haku SQL-taulusta
        NorthwindContext konteksti = new();
        List<Customer> asiakkaat = (from c in konteksti.Customers
                                    where c.Country == maa
                                    select c).ToList();
        return asiakkaat;
        */

        // käyttäen tallennettua proseduuria (stored procedure)
        NorthwindContext konteksti = new();
        List<Customer> asiakkaat = konteksti.Customers.FromSql(
            $"AsiakkaatMaasta {maa}").ToList();
        return asiakkaat;
    }
}
