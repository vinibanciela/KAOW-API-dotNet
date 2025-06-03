using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KAOW.Data;
using KAOW.Models;

namespace KAOW.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Rota base: api/EventoExtremo
    public class EventoExtremoController : ControllerBase
    {
        private readonly CrisisDbContext _context;

        public EventoExtremoController(CrisisDbContext context)
        {
            _context = context;
        }

        // GET: api/EventoExtremo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventoExtremo>>> GetAll()
        {
            return await _context.EventosExtremos.ToListAsync();
        }

        // GET: api/EventoExtremo/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EventoExtremo>> GetById(int id)
        {
            var evento = await _context.EventosExtremos.FindAsync(id);
            if (evento == null) return NotFound();
            return evento;
        }

        // POST: api/EventoExtremo
        [HttpPost]
        public async Task<ActionResult<EventoExtremo>> Create(EventoExtremo evento)
        {
            _context.EventosExtremos.Add(evento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }

        // PUT: api/EventoExtremo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventoExtremo evento)
        {
            if (id != evento.Id) return BadRequest();
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/EventoExtremo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _context.EventosExtremos.FindAsync(id);
            if (evento == null) return NotFound();
            _context.EventosExtremos.Remove(evento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
