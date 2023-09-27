using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWebApi.Controllers
{
    [Route("api/asiakas")]
    [ApiController]
    public class AsiakkaatApiController : ControllerBase
    {
        [HttpGet]
        [Route("{asiakasId}")]
        public string TilausNumerolla(string asiakasId)
        {
            return $"Asiakkaan {asiakasId} tiedot..";
        }
    }
}
