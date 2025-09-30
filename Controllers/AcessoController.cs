using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]

public class AcessoController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "IdadeMinima")]
    [Authorize(AuthenticationSchemes = "Bearer")] 
    public IActionResult Get()
    {
        return Ok("Acesso permitido!");
    }
}