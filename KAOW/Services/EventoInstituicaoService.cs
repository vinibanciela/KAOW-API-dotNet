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

        // Retorna todos os vínculos entre EventoExtremo e Instituicao (GET simples)
        public async Task<List<EventoInstituicaoDTO>> GetAllAsync()
        {
            return await _context.EventoInstituicoes
                .Select(ei => new EventoInstituicaoDTO
                {
                    EventoExtremoId = ei.EventoExtremoId,
                    InstituicaoId = ei.InstituicaoId
                })
                .ToListAsync();
        }

        // Retorna um vínculo específico entre EventoExtremo e Instituicao (Get específico)
        public async Task<EventoInstituicaoDTO?> GetByIdsAsync(int eventoId, int instituicaoId)
        {
            var vinculo = await _context.EventoInstituicoes
                .FirstOrDefaultAsync(ei => ei.EventoExtremoId == eventoId && ei.InstituicaoId == instituicaoId);

            if (vinculo == null) return null;

            return new EventoInstituicaoDTO
            {
                EventoExtremoId = vinculo.EventoExtremoId,
                InstituicaoId = vinculo.InstituicaoId
            };
        }

        // Cria o vínculo entre EventoExtremo e Instituicao (POST)
        public async Task<EventoInstituicaoDTO> CreateAsync(EventoInstituicaoDTO dto)
        {
            var existe = await _context.EventoInstituicoes
                .AnyAsync(ei => ei.EventoExtremoId == dto.EventoExtremoId && ei.InstituicaoId == dto.InstituicaoId);

            if (existe)
                throw new InvalidOperationException("Vínculo já existente.");

            var vinculo = new EventoInstituicao
            {
                EventoExtremoId = dto.EventoExtremoId,
                InstituicaoId = dto.InstituicaoId
            };

            _context.EventoInstituicoes.Add(vinculo);
            await _context.SaveChangesAsync();

            return dto;
        }

        // Remove o vínculo entre EventoExtremo e Instituicao (DELETE)
        public async Task<bool> DeleteAsync(int eventoId, int instituicaoId)
        {
            var vinculo = await _context.EventoInstituicoes
                .FirstOrDefaultAsync(ei => ei.EventoExtremoId == eventoId && ei.InstituicaoId == instituicaoId);

            if (vinculo == null) return false;

            _context.EventoInstituicoes.Remove(vinculo);
            await _context.SaveChangesAsync();
            return true;
        }
        /*
        // Lista os nomes das instituições vinculadas a um evento extremo (DESATIVADA - pois já temos GET DETAILS)
        public async Task<List<string>> ListarInstituicoesPorEventoAsync(int eventoId)
        {
            return await _context.EventoInstituicoes
                .Where(ei => ei.EventoExtremoId == eventoId)
                .Select(ei => ei.Instituicao.Nome)
                .ToListAsync();
        }

        // Lista os tipos dos eventos extremos vinculados a uma instituição (DESATIVADA - pois já temos GET DETAILS)
        public async Task<List<string>> ListarEventosPorInstituicaoAsync(int instituicaoId)
        {
            return await _context.EventoInstituicoes
                .Where(ei => ei.InstituicaoId == instituicaoId)
                .Select(ei => ei.EventoExtremo.Tipo)
                .ToListAsync();
        }
        */
    }
}
