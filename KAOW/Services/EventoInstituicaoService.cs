using KAOW.Data;
using KAOW.Models;
using KAOW.DTOs;
using Microsoft.EntityFrameworkCore;

namespace KAOW.Services
{
    public class EventoInstituicaoService
    {
        private readonly CrisisDbContext _context;

        public EventoInstituicaoService(CrisisDbContext context)
        {
            _context = context;
        }

        // Cria o vínculo entre EventoExtremo e Instituicao
        public async Task<bool> VincularAsync(EventoInstituicaoDTO dto)
        {
            var existe = await _context.EventoInstituicoes
                .AnyAsync(ei => ei.EventoExtremoId == dto.EventoExtremoId && ei.InstituicaoId == dto.InstituicaoId);

            if (existe) return false;

            var vinculo = new EventoInstituicao
            {
                EventoExtremoId = dto.EventoExtremoId,
                InstituicaoId = dto.InstituicaoId
            };

            _context.EventoInstituicoes.Add(vinculo);
            await _context.SaveChangesAsync();
            return true;
        }

        // Remove o vínculo entre EventoExtremo e Instituicao
        public async Task<bool> DesvincularAsync(EventoInstituicaoDTO dto)
        {
            var vinculo = await _context.EventoInstituicoes
                .FirstOrDefaultAsync(ei => ei.EventoExtremoId == dto.EventoExtremoId && ei.InstituicaoId == dto.InstituicaoId);

            if (vinculo == null) return false;

            _context.EventoInstituicoes.Remove(vinculo);
            await _context.SaveChangesAsync();
            return true;
        }
        
        // Lista os nomes das instituições vinculadas a um evento extremo
        public async Task<List<string>> ListarInstituicoesPorEventoAsync(int eventoId)
        {
            return await _context.EventoInstituicoes
                .Where(ei => ei.EventoExtremoId == eventoId)
                .Select(ei => ei.Instituicao.Nome)
                .ToListAsync();
        }

        // Lista os tipos dos eventos extremos vinculados a uma instituição
        public async Task<List<string>> ListarEventosPorInstituicaoAsync(int instituicaoId)
        {
            return await _context.EventoInstituicoes
                .Where(ei => ei.InstituicaoId == instituicaoId)
                .Select(ei => ei.EventoExtremo.Tipo)
                .ToListAsync();
        }
    }
}