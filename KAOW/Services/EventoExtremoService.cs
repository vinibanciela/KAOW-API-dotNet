using KAOW.DTOs;
using KAOW.Models;
using KAOW.Data;
using Microsoft.EntityFrameworkCore;

namespace KAOW.Services
{
    public class EventoExtremoService
    {
        private readonly CrisisDbContext _context;

        public EventoExtremoService(CrisisDbContext context)
        {
            _context = context;
        }

        // Retorna todos os eventos extremos (GET simples)
        public async Task<List<EventoExtremoDTO>> GetAllAsync()
        {
            return await _context.EventosExtremos
                .Select(e => new EventoExtremoDTO
                {
                    Id = e.Id,
                    Descricao = e.Descricao,
                    Data = e.Data,
                    Tipo = e.Tipo,
                    Local = e.Local
                })
                .ToListAsync();
        }

        // Retorna um evento extremo detalhado com relacionamentos (GET detalhado)
        public async Task<EventoExtremoDetailDTO?> GetDetailByIdAsync(int id)
        {
            var evento = await _context.EventosExtremos
                .Include(e => e.BasesEmergencia)
                .Include(e => e.EventoInstituicoes)
                .ThenInclude(ei => ei.Instituicao)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evento == null) return null;

            return new EventoExtremoDetailDTO
            {
                Id = evento.Id,
                Descricao = evento.Descricao,
                Data = evento.Data,
                Tipo = evento.Tipo,
                Local = evento.Local,
                BasesEmergencia = evento.BasesEmergencia
                    .Select(b => b.Localizacao)
                    .ToList(),
                Instituicoes = evento.EventoInstituicoes
                    .Select(ei => ei.Instituicao.Nome)
                    .ToList()
            };
        }

        // Criação de evento extremo (POST)
        public async Task<EventoExtremo> CreateAsync(CreateEventoExtremoDTO dto)
        {
            var evento = new EventoExtremo
            {
                Descricao = dto.Descricao,
                Data = dto.Data,
                Tipo = dto.Tipo,
                Local = dto.Local
            };

            _context.EventosExtremos.Add(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        // Atualização de evento extremo (PUT)
        public async Task<EventoExtremo?> UpdateAsync(UpdateEventoExtremoDTO dto)
        {
            var evento = await _context.EventosExtremos.FindAsync(dto.Id);
            if (evento == null) return null;

            evento.Descricao = dto.Descricao;
            evento.Data = dto.Data;
            evento.Tipo = dto.Tipo;
            evento.Local = dto.Local;

            await _context.SaveChangesAsync();
            return evento;
        }

        // Remoção de evento extremo (DELETE)
        public async Task<bool> DeleteAsync(int id)
        {
            var evento = await _context.EventosExtremos.FindAsync(id);
            if (evento == null) return false;

            _context.EventosExtremos.Remove(evento);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
