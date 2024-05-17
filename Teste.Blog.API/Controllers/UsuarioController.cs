using Microsoft.AspNetCore.Mvc;
using Teste.Blog.Domain.Interfaces.Services;
using Teste.Blog.Domain.Request;

namespace Teste.Blog.API.Controllers
{  

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        [HttpPost("InsertUsuario")]
        public async Task<IActionResult> Register([FromBody] UsuarioRequest request)
        {
            await _UsuarioService.InsertUsuario(request);
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UsuarioRequest request)
        {
            var authenticatedUser = await _UsuarioService.Autenticar(request.LoginUsuario, request.SenhaUsuario);
            if (authenticatedUser == null)
                return Unauthorized();
            return Ok(authenticatedUser);
        }
    }
}
