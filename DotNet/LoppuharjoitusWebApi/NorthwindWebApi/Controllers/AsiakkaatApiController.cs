using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Entities;
using NorthwindWebApi.Logiikka;

namespace NorthwindWebApi.Controllers
{
    [Route("api/asiakas")]
    [ApiController]
    public class AsiakkaatApiController : ControllerBase
    {
        [HttpGet]
        [Route("{asiakasId}")]
        public Customer? AsiakasIdllä(string asiakasId)
        {
            // SQL-tietokannan käsittely
            NorthwindContext konteksti = new();
            Customer? asiakas = konteksti.Customers.Where(
                c => c.CustomerId == asiakasId).FirstOrDefault();

            // XML-aineiston käsittely
            XmlKäsittely xml = new();
            if (asiakas != null)
            {
                string igTunnus = xml.HaeAsiakkaanLisätiedot(asiakasId);
                asiakas.InstagramTunnus = igTunnus;

                // palautetaan tulokset
                return asiakas;
            }
            else
            {
                return null;
            }
        }
    }
}
