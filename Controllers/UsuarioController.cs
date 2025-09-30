using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsuarioApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase
    {

        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private CadastroService _cadastroService;

        public UsuarioController(IMapper mapper, UserManager<Usuario> userManage)
        {
            _mapper = mapper;
            _userManager = userManage;
        }
        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
        {
            await _cadastroService.Cadastra(dto);
            return Ok("Usuário cadastrado!");
        }
        

    }
}