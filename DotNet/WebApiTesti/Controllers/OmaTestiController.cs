using Microsoft.AspNetCore.Mvc;

namespace WebApiTesti.Controllers;

[ApiController]
[Route("[controller]")]
public class OmaTestiController : ControllerBase
{
    public string SanoMoi()
    {
        return "Moi maailma!";
    }
}
