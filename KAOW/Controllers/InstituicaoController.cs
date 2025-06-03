using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KAOW.Data;
using KAOW.Models;

namespace KAOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota base como "api/Instituicao"
    public class InstituicaoController : ControllerBase
    {
        private readonly CrisisDbContext _context;

        // Injeção do DbContext via construtor
        public InstituicaoController(CrisisDbContext context)
        {
            _context = context;
        }

        // GET: api/Instituicao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instituicao>>> GetAll()
        {
            return await _context.Instituicoes.ToListAsync();
        }

        // GET: api/Instituicao/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Instituicao>> GetById(int id)
        {
            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao == null) return NotFound();
            return instituicao;
        }

        // POST: api/Instituicao
        [HttpPost]
        public async Task<ActionResult<Instituicao>> Create(Instituicao instituicao)
        {
            _context.Instituicoes.Add(instituicao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = instituicao.Id }, instituicao);
        }

        // PUT: api/Instituicao/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Instituicao instituicao)
        {
            if (id != instituicao.Id) return BadRequest();
            _context.Entry(instituicao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Instituicao/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao == null) return NotFound();
            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
