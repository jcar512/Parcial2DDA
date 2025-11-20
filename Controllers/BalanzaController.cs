using Microsoft.AspNetCore.Mvc;
using Parcial2DDA.Models;
using Parcial2DDA.Services;

namespace Parcial2DDA.Controllers
{
    [ApiController]
    public class BalanzaController : Controller
    {
        private readonly IBalanzaService _balanzaService;

        public BalanzaController(IBalanzaService balanzaService)
        {
            _balanzaService = balanzaService;
        }

        [HttpPost("/medicion")]
        public async Task<IActionResult> GuardarRegistro([FromBody] RegistroDto registro)
        {
            if(registro == null)return BadRequest("Request vacio");

         
            return Ok( await _balanzaService.NuevoRegistro(registro));  
        }

        [HttpGet("/reportes/total")]
        public async Task<IActionResult> ObtenerCantidadDeReportes()
        {
            return Ok(await _balanzaService.TotalMedicionesRealizadas());
        }

        [HttpGet("/reportes/maxima_diferencia_peso")]
        public async Task<IActionResult> ObtenerMaximaDiferenciaPeso()
        {
            return Ok(await _balanzaService.MaximadiferenciaPeso());
        }
        
        [HttpGet("/reportes/maximo_tiempo")]
        public async Task<IActionResult> ObtenerTiempoMaximoLocal()
        {
            return Ok(await _balanzaService.MaximoTiempoLocal());
        }
    }
}