using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsuarioApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService;

        public UsuarioController(UsuarioService cadastroService)
        {
            _usuarioService = cadastroService;
        }
        
        /// <summary>
        /// Cadastra um usuário ao banco de dados
        /// </summary>
        /// <param name="dto">Objeto com os campos necessários para criação de um usuário</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a criaçao seja feita com sucesso</response>
        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastraUsuario
            (CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraUsuario(dto);
            return Ok("Usuário cadastrado!");
        }

        /// <summary>
        /// Login do usuário
        /// </summary>
        /// <param name="dto">Objeto com os campos necessários para o login do usuário:</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso o login seja realizado com sucesso! Irá retorna o Token</response>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.Login(dto);
            return Ok($"Login realizado com sucesso! Token: {token}");
        }
    }
}