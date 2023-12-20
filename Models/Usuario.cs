
    namespace DesafioBackEndPL.Models
    {
        public class Usuario
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Genero { get; set; }
            public DateTime DataNascimento { get; set; }
            public string FotoPerfil { get; set; }            
            public List<Postagem> Postagens { get; set; }
        }
    }



