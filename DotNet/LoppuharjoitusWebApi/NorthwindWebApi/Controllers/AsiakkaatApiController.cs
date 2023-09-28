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
        public CustomerLaajennus? AsiakasIdllä(string asiakasId)
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
                CustomerLaajennus asiakas2 = new()
                {
                    InstagramTunnus = igTunnus,
                    CustomerId = asiakas.CustomerId,
                    CompanyName = asiakas.CompanyName,
                    Country = asiakas.Country,
                    ContactName = asiakas.ContactName
                };

                // palautetaan tulokset
                return asiakas2;
            }
            else
            {
                return null;
            }
        }
    }
}
