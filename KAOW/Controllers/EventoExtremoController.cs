using KAOW.DTOs;
using KAOW.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KAOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EventoExtremoController : ControllerBase
    {
        private readonly EventoExtremoService _service;

        public EventoExtremoController(EventoExtremoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todos os eventos extremos registrados (GET simples).
        /// </summary>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar eventos extremos",
            Description = "Retorna uma lista de todos os eventos extremos cadastrados, sem incluir relacionamentos."
        )]
        [ProducesResponseType(typeof(IEnumerable<EventoExtremoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EventoExtremoDTO>>> GetAll()
        {
            var eventos = await _service.GetAllAsync();
            return Ok(eventos);
        }

        /// <summary>
        /// Retorna os detalhes de um evento extremo pelo ID (GET detalhado).
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Buscar evento extremo por ID",
            Description = "Retorna os dados detalhados do evento extremo, incluindo instituições e bases relacionadas."
        )]
        [ProducesResponseType(typeof(EventoExtremoDetailDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EventoExtremoDetailDTO>> GetById(int id)
        {
            var evento = await _service.GetDetailByIdAsync(id);
            if (evento == null) return NotFound();
            return Ok(evento);
        }

        /// <summary>
        /// Cria um novo evento extremo (POST).
        /// </summary>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Criar novo evento extremo",
            Description = "Adiciona um novo evento extremo com os dados fornecidos."
        )]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateEventoExtremoDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza um evento extremo existente (PUT).
        /// </summary>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualizar evento extremo",
            Description = "Atualiza os dados do evento extremo com base no ID fornecido."
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, UpdateEventoExtremoDTO dto)
        {
            if (id != dto.Id) return BadRequest("ID da URL não corresponde ao corpo da requisição.");

            var updated = await _service.UpdateAsync(dto);
            if (updated == null) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Remove um evento extremo (DELETE).
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir evento extremo",
            Description = "Remove um evento extremo com base no ID fornecido."
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
