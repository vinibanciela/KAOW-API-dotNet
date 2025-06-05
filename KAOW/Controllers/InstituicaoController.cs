using KAOW.DTOs;
using KAOW.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KAOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoService _service;

        public InstituicaoController(InstituicaoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas as instituições cadastradas (GET simples).
        /// </summary>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Listar instituições",
            Description = "Retorna uma lista de todas as instituições cadastradas no sistema, sem incluir relacionamentos."
        )]
        [ProducesResponseType(typeof(IEnumerable<InstituicaoDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InstituicaoDTO>>> GetAll()
        {
            var instituicoes = await _service.GetAllAsync();
            return Ok(instituicoes);
        }

        /// <summary>
        /// Retorna os detalhes de uma instituição pelo ID (GET detalhado).
        /// </summary>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Buscar instituição por ID",
            Description = "Retorna os dados detalhados da instituição, incluindo relacionamentos com bases de emergência e eventos extremos."
        )]
        [ProducesResponseType(typeof(InstituicaoDetailDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InstituicaoDetailDTO>> GetById(int id)
        {
            var instituicao = await _service.GetDetailByIdAsync(id);
            if (instituicao == null) return NotFound();
            return Ok(instituicao);
        }

        /// <summary>
        /// Cria uma nova instituição (POST).
        /// </summary>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Criar nova instituição",
            Description = "Adiciona uma nova instituição no sistema com os dados fornecidos."
        )]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateInstituicaoDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Atualiza uma instituição existente (PUT).
        /// </summary>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Atualizar instituição",
            Description = "Atualiza os dados da instituição com base no ID fornecido."
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(int id, UpdateInstituicaoDTO dto)
        {
            if (id != dto.Id) return BadRequest("ID da URL não corresponde ao corpo da requisição.");

            var updated = await _service.UpdateAsync(dto);
            if (updated == null) return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Remove uma instituição existente (DELETE).
        /// </summary>
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Excluir instituição",
            Description = "Remove uma instituição do sistema com base no ID fornecido."
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
