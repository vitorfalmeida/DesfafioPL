namespace DesafioBackEndPL.Dtos
{
    public class PostagemDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string UrlFoto { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }        
    }
}
