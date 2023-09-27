using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Entities;

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
            NorthwindContext konteksti = new();
            Customer? asiakas = konteksti.Customers.Where(
                c => c.CustomerId == asiakasId).FirstOrDefault();

            return asiakas;
        }
    }
}
