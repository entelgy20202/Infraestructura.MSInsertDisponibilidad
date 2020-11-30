using Infraestructura.MSInsertDisponibilidad.Domain.Interfaces;
using Infraestructura.MSInsertDisponibilidad.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Infraestructura.MSInsertDisponibilidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadController : ControllerBase
    {
        private readonly IInsertarDisponibilidad _domain;

        public DisponibilidadController(IInsertarDisponibilidad domain)
        {
            _domain = domain;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DisponibilidadDTO disponibilidad)
        {
            var result = await _domain.ExecuteAsync(disponibilidad).ConfigureAwait(false);
            return Ok(result);
        }
    }
}