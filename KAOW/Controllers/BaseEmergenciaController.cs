using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KAOW.Data;
using KAOW.Models;

namespace KAOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Rota base: api/BaseEmergencia
    public class BaseEmergenciaController : ControllerBase
    {
        private readonly CrisisDbContext _context;

        public BaseEmergenciaController(CrisisDbContext context)
        {
            _context = context;
        }

        // GET: api/BaseEmergencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseEmergencia>>> GetAll()
        {
            return await _context.BasesEmergencias.ToListAsync();
        }

        // GET: api/BaseEmergencia/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BaseEmergencia>> GetById(int id)
        {
            var baseE = await _context.BasesEmergencias.FindAsync(id);
            if (baseE == null) return NotFound();
            return baseE;
        }

        // POST: api/BaseEmergencia
        [HttpPost]
        public async Task<ActionResult<BaseEmergencia>> Create(BaseEmergencia baseE)
        {
            _context.BasesEmergencias.Add(baseE);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = baseE.Id }, baseE);
        }

        // PUT: api/BaseEmergencia/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BaseEmergencia baseE)
        {
            if (id != baseE.Id) return BadRequest();
            _context.Entry(baseE).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/BaseEmergencia/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var baseE = await _context.BasesEmergencias.FindAsync(id);
            if (baseE == null) return NotFound();
            _context.BasesEmergencias.Remove(baseE);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
