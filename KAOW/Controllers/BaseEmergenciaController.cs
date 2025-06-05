using KAOW.DTOs;
using KAOW.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KAOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class BaseEmergenciaController : ControllerBase
    {
        private readonly BaseEmergenciaService _service;

        public BaseEmergenciaController(BaseEmergenciaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas as bases de emergência (GET simples).
        /// </summary>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar bases de emergência",
            Description = "Retorna uma lista de todas as bases de emergência cadastradas, sem incluir dados de instituição ou evento extremo."
        )]
        [ProducesResponseType(typeof(IEnumerable<BaseEmergenciaDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BaseEmergenciaDTO>>> GetAll()
        {
            var bases = await _service.GetAllAsync();
            return Ok(bases);
        }

        /// <summary>
        /// Retorna detalhes de uma base de emergência por ID (GET detalhado).
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Buscar base de emergência por ID",
            Description = "Retorna os dados detalhados da base, incluindo nome da instituição e descrição do evento extremo relacionados."
        )]
        [ProducesResponseType(typeof(BaseEmergenciaDetailDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseEmergenciaDetailDTO>> GetById(int id)
        {
            var baseDetail = await _service.GetDetailByIdAsync(id);
            if (baseDetail == null) return NotFound();
            return Ok(baseDetail);
        }

        /// <summary>
        /// Cria uma nova base de emergência (POST).
        /// </summary>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Criar nova base de emergência",
            Description = "Adiciona uma nova base de emergência no sistema com os dados fornecidos."
        )]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateBaseEmergenciaDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma base de emergência existente (PUT).
        /// </summary>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualizar base de emergência",
            Description = "Atualiza os dados da base de emergência com base no ID fornecido."
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, UpdateBaseEmergenciaDTO dto)
        {
            if (id != dto.Id) return BadRequest("ID da URL não corresponde ao corpo da requisição.");

            var updated = await _service.UpdateAsync(dto);
            if (updated == null) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Remove uma base de emergência (DELETE).
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir base de emergência",
            Description = "Remove uma base de emergência com base no ID fornecido."
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
