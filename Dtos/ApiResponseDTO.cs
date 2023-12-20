namespace DesafioBackEndPL.Dtos
{
    namespace DesafioBackEndPL.Dtos
    {
        public class ApiResponseDTO
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public int TotalUsers { get; set; }
            public int Offset { get; set; }
            public int Limit { get; set; }
            public List<UsuarioDTO> Users { get; set; }
        }
    }

}
