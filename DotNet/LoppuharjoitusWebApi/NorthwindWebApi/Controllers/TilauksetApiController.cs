using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Entities;
using NorthwindWebApi.Logiikka;

namespace NorthwindWebApi.Controllers
{
    [Route("api/tilaus")]
    [ApiController]
    public class TilauksetApiController : ControllerBase
    {
        [HttpGet]
        [Route("{numero:int}")]
        public Order? TilausNumerolla(int numero)
        {
            // SQL-tietokannan käsittely
            NorthwindContext konteksti = new();
            Order? tilaus = konteksti.Orders.Where(
                o => o.OrderId == numero).FirstOrDefault();

            // XML-aineiston käsittely
            XmlKäsittely xml = new();
            if (tilaus != null)
            {
                string ohje = xml.HaeTilauksenLisätiedot(numero);
                tilaus.KäsittelyOhjeet = ohje;

                // palautetaan tulokset
                return tilaus;
            }
            else
            {
                return null;
            }
        }
    }
}
