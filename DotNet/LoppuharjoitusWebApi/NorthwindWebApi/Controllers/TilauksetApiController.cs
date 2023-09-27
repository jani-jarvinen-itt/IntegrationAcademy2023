using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Entities;

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
            NorthwindContext konteksti = new();
            Order? tilaus = konteksti.Orders.Where(
                o => o.OrderId == numero).FirstOrDefault();

            return tilaus;
        }
    }
}
