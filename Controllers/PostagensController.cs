using DesafioBackEndPL.Data.Context;
using DesafioBackEndPL.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DesafioBackEndPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagensController : ControllerBase
    {
        private readonly DesafioDbContext _dbContext;

        public PostagensController(DesafioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostagemDTO>> GetPostagem(int id)
        {
            var postagem = await _dbContext.Postagens
                .FirstOrDefaultAsync(p => p.Id == id);

            if (postagem == null)
            {
                return NotFound();
            }

            var postagemDto = new PostagemDTO
            {
                Id = postagem.Id,
                Titulo = postagem.Titulo,
                Conteudo = postagem.Conteudo,
                UrlFoto = postagem.UrlFoto,
                Descricao = postagem.Descricao,
                UsuarioId = postagem.UsuarioId
            };

            return Ok(postagemDto);
        }
    }

}
