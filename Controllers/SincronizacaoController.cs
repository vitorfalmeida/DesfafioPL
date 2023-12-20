using DesafioBackEndPL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioBackEndPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SincronizacaoController : ControllerBase
    {
        private readonly SincronizacaoService _sincronizacaoService;

        public SincronizacaoController(SincronizacaoService sincronizacaoService)
        {
            _sincronizacaoService = sincronizacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Sincronizar()
        {
            try
            {
                await _sincronizacaoService.SincronizarDadosAsync();
                return Ok("Sincronização concluída com sucesso.");
            }           
            catch (Exception ex)
            {
                // Tratamento para exceções não esperadas
                // Log do erro para um sistema de monitoramento de erros
                // Considerar o uso de um serviço de logging como Serilog, NLog, etc.
                return StatusCode(500, "Ocorreu um erro inesperado durante a sincronização: " + ex.Message);
            }
        }
    }
}
