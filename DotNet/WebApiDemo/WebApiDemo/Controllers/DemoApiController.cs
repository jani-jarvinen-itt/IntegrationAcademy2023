using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/demo")]
    [ApiController]
    public class DemoApiController : ControllerBase
    {
        [HttpGet]
        [Route("parametrit")]
        public string Parametrit(string nimi, int ikä)
        {
            return $"Parametrien arvot: nimi={nimi}, ikä={ikä}.";
        }

        [HttpPost]
        [Route("sisältö")]
        public string Sisältö([FromBody] Henkilö henkilö)
        {
            return $"Syötteen arvot: nimi={henkilö.Nimi}, ikä={henkilö.Ikä}.";
        }
    }
}
