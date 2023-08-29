using Microsoft.AspNetCore.Mvc;

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
    }
}
