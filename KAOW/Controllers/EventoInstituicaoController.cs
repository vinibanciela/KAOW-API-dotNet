using Microsoft.AspNetCore.Mvc;
using KAOW.Services;
using KAOW.DTOs;

namespace KAOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoInstituicaoController : ControllerBase
    {
        private readonly EventoInstituicaoService _service;

        public EventoInstituicaoController(EventoInstituicaoService service)
        {
            _service = service;
        }

        // POST: api/EventoInstituicao → Cria vínculo
        [HttpPost]
        public async Task<IActionResult> Vincular([FromBody] EventoInstituicaoDTO dto)
        {
            var sucesso = await _service.VincularAsync(dto);
            if (!sucesso) return Conflict("Vínculo já existente.");
            return Ok("Vínculo criado com sucesso.");
        }

        // DELETE: api/EventoInstituicao → Remove vínculo
        [HttpDelete]
        public async Task<IActionResult> Desvincular([FromBody] EventoInstituicaoDTO dto)
        {
            var sucesso = await _service.DesvincularAsync(dto);
            if (!sucesso) return NotFound("Vínculo não encontrado.");
            return Ok("Vínculo removido com sucesso.");
        }
        
        // GET: api/EventoInstituicao/evento/{eventoId}
        [HttpGet("evento/{eventoId}")]
        public async Task<IActionResult> GetInstituicoesPorEvento(int eventoId)
        {
            var instituicoes = await _service.ListarInstituicoesPorEventoAsync(eventoId);
            return Ok(instituicoes);
        }

        // GET: api/EventoInstituicao/instituicao/{instituicaoId}
        [HttpGet("instituicao/{instituicaoId}")]
        public async Task<IActionResult> GetEventosPorInstituicao(int instituicaoId)
        {
            var eventos = await _service.ListarEventosPorInstituicaoAsync(instituicaoId);
            return Ok(eventos);
        }
    }
}