    namespace DesafioBackEndPL.Models
    {
        public class Postagem
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Conteudo { get; set; }
            public DateTime DataPublicacao { get; set; }
            public string UrlFoto { get; set; }
            public string Descricao { get; set; }
            public string Categoria { get; set; }            
            public int UsuarioId { get; set; }            
            public Usuario Usuario { get; set; }
        }
    }



