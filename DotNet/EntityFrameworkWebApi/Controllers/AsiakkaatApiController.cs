using EntityFrameworkWebApi.Models;
using Microsoft.AspNetCore.Mvc;

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
        NorthwindContext konteksti = new();
        List<Customer> asiakkaat = (from c in konteksti.Customers
                                    where c.Country == maa
                                    select c).ToList();
        return asiakkaat;
    }
}
