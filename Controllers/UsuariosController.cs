using DesafioBackEndPL.Data.Context;
using DesafioBackEndPL.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DesafioBackEndPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DesafioDbContext _dbContext;

        public UsuariosController(DesafioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios
                .Include(u => u.Postagens)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioDto = new UsuarioDTO
            {
                Id = usuario.Id,
                NomeCompleto = usuario.Nome,
                Email = usuario.Email,
                FotoPerfil = usuario.FotoPerfil                
            };

            return Ok(usuarioDto);
        }
    }

}
