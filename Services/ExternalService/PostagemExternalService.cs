using DesafioBackEndPL.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using DesafioBackEndPL.Dtos;

namespace DesafioBackEndPL.Services.ExternalService
{
    public class PostagemExternalService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.slingacademy.com/v1/sample-data/blog-posts";

        public PostagemExternalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostagemDTO>> GetPostagensAsync(int offset = 0, int limit = 100)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}?offset={offset}&limit={limit}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();            
            var postagens = JsonSerializer.Deserialize<List<PostagemDTO>>(content);
            return postagens;
        }
    }
}
