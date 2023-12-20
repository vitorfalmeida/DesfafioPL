using DesafioBackEndPL.Data.Context;
using DesafioBackEndPL.Models;
using DesafioBackEndPL.Services.ExternalService;

namespace DesafioBackEndPL.Services
{
    public class SincronizacaoService
    {
        private readonly UsuarioExternalService _usuarioService;
        private readonly PostagemExternalService _postagemService;
        private readonly DesafioDbContext _dbContext;

        public SincronizacaoService(UsuarioExternalService usuarioService, PostagemExternalService postagemService, DesafioDbContext dbContext)
        {
            _usuarioService = usuarioService;
            _postagemService = postagemService;
            _dbContext = dbContext;
        }

        public async Task SincronizarDadosAsync()
        {
            var usuariosDto = await _usuarioService.GetUsuariosAsync();
            if (usuariosDto == null)
            {
                throw new InvalidOperationException("Não foi possível obter os dados dos usuários da API externa.");
            }
            foreach (var usuarioDto in usuariosDto)
            {
                var usuarioExistente = await _dbContext.Usuarios.FindAsync(usuarioDto.Id);
                if (usuarioExistente == null)
                {
                    var novoUsuario = new Usuario
                    {
                        Id = usuarioDto.Id,
                        Nome = usuarioDto.NomeCompleto,
                        Email = usuarioDto.Email,
                        FotoPerfil = usuarioDto.FotoPerfil,                        
                    };
                    _dbContext.Usuarios.Add(novoUsuario);
                }
                else
                {
                    usuarioExistente.Nome = usuarioDto.NomeCompleto;
                    usuarioExistente.Email = usuarioDto.Email;
                    usuarioExistente.FotoPerfil = usuarioDto.FotoPerfil;                    
                }
            }

            var postagensDto = await _postagemService.GetPostagensAsync();
            if (postagensDto == null)
            {
                throw new InvalidOperationException("Não foi possível obter os dados das postagens da API externa.");
            }
            foreach (var postagemDto in postagensDto)
            {
                var postagemExistente = await _dbContext.Postagens.FindAsync(postagemDto.Id);
                if (postagemExistente == null)
                {
                    var novaPostagem = new Postagem
                    {
                        Id = postagemDto.Id,
                        Titulo = postagemDto.Titulo,
                        Conteudo = postagemDto.Conteudo,
                        UrlFoto = postagemDto.UrlFoto,
                        Descricao = postagemDto.Descricao,
                        UsuarioId = postagemDto.UsuarioId
                    };
                    _dbContext.Postagens.Add(novaPostagem);
                }
                else
                {
                    postagemExistente.Titulo = postagemDto.Titulo;
                    postagemExistente.Conteudo = postagemDto.Conteudo;
                    postagemExistente.UrlFoto = postagemDto.UrlFoto;
                    postagemExistente.Descricao = postagemDto.Descricao;
                    postagemExistente.UsuarioId = postagemDto.UsuarioId;
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }

}
