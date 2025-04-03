using Microsoft.AspNetCore.Mvc;

namespace Clients.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new
        {
            Message = "Bem vindo a API",
            DataAcesso = DateTime.Now.ToLongDateString(),
        });
    }
}