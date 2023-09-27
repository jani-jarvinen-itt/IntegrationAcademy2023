using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWebApi.Controllers
{
    [Route("api/tilaus")]
    [ApiController]
    public class TilauksetApiController : ControllerBase
    {
        [HttpGet]
        [Route("{numero:int}")]
        public string TilausNumerolla(int numero)
        {
            return $"Tilauksen {numero} tiedot..";
        }
    }
}
