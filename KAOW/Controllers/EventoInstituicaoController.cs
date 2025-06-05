using KAOW.DTOs;
using KAOW.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KAOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EventoInstituicaoController : ControllerBase
    {
        private readonly EventoInstituicaoService _service;

        public EventoInstituicaoController(EventoInstituicaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todos os relacionamentos entre eventos extremos e instituições (GET simples).
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Listar todos os vínculos", Description = "Retorna todos os vínculos EventoExtremo-Instituicao cadastrados")]
        [ProducesResponseType(typeof(IEnumerable<EventoInstituicaoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EventoInstituicaoDTO>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        /// <summary>
        /// Retorna um vínculo específico por ID composto (GET específico).
        /// </summary>
        [HttpGet("evento/{eventoId}/instituicao/{instituicaoId}")]
        [SwaggerOperation(Summary = "Buscar vínculo específico", Description = "Busca o vínculo entre um EventoExtremo e uma Instituição pelo ID de ambos")]
        [ProducesResponseType(typeof(EventoInstituicaoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventoInstituicaoDTO>> GetByIds(int eventoId, int instituicaoId)
        {
            var item = await _service.GetByIdsAsync(eventoId, instituicaoId);
            if (item == null) return NotFound();
            return Ok(item);
        }

        /// <summary>
        /// Cria um novo vínculo entre evento extremo e instituição (POST).
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Criar vínculo", Description = "Cria um novo vínculo entre EventoExtremo e Instituição")]
        [ProducesResponseType(typeof(EventoInstituicaoDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EventoInstituicaoDTO>> Create(EventoInstituicaoDTO dto)
        {
            try
            {
                var criado = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetByIds), new { eventoId = criado.EventoExtremoId, instituicaoId = criado.InstituicaoId }, criado);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Remove um vínculo existente entre evento extremo e instituição (DELETE).
        /// </summary>
        [HttpDelete("evento/{eventoId}/instituicao/{instituicaoId}")]
        [SwaggerOperation(Summary = "Excluir vínculo", Description = "Remove um vínculo específico entre EventoExtremo e Instituição")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int eventoId, int instituicaoId)
        {
            var removido = await _service.DeleteAsync(eventoId, instituicaoId);
            if (!removido) return NotFound();
            return NoContent();
        }
    }
}
