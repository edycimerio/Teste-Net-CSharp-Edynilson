using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Teste.Blog.Domain.Interfaces.Services;
using Teste.Blog.Domain.Request;

namespace Teste.Blog.API.Controllers
{  

    [ApiController]
    [Route("api/[controller]")]
    public class PostagemController : ControllerBase
    {
        private readonly IPostagemService _postagemService;

        public PostagemController(IPostagemService postagemService)
        {
            _postagemService = postagemService;
        }

       

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postagemService.GetPostagemtById(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostagemt()
        {
            var post = await _postagemService.GetAllPostagemt();
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostagemRequest request)
        {
            await _postagemService.InsertPostagem(request);
            return CreatedAtAction(nameof(Get), new { id = request.IdPostagem }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PostagemRequest request)
        {
            if (id != request.IdPostagem)
                return BadRequest();

            await _postagemService.UpdatePostagem(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postagemService.DeletePostagem(id);
            return NoContent();
        }
    }
}
