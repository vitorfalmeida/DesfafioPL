using DesafioBackEndPL.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using DesafioBackEndPL.Dtos;
using DesafioBackEndPL.Dtos.DesafioBackEndPL.Dtos;

namespace DesafioBackEndPL.Services.ExternalService
{
    public class UsuarioExternalService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.slingacademy.com/v1/sample-data/users";

        public UsuarioExternalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UsuarioDTO>> GetUsuariosAsync(int offset = 0, int limit = 100)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?offset={offset}&limit={limit}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true 
            };
            var apiResponse = JsonSerializer.Deserialize<ApiResponseDTO>(content, options);
            if (!apiResponse?.Success ?? true)
            {
                throw new Exception("A API não retornou sucesso.");
            }
            return apiResponse.Users ?? new List<UsuarioDTO>();
        }

    }
}
