using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsuariosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessoController : ControllerBase
    {
        /// <summary>
        /// Verifica se o token de acesso é válido (Verifique a autenticação através do Postman (Token Bearer))
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a autenticação seja realizada com sucesso</response>
        [HttpGet]
        [Authorize(Policy = "IdadeMinima")]
        public IActionResult Get() 
        {
            return Ok("Acesso permitido!");
        }
    }
}