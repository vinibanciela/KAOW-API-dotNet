using KAOW.DTOs;
using KAOW.Models;
using KAOW.Data;
using Microsoft.EntityFrameworkCore;

namespace KAOW.Services
{
    public class BaseEmergenciaService
    {
        private readonly CrisisDbContext _context;

        public BaseEmergenciaService(CrisisDbContext context)
        {
            _context = context;
        }

        // Retorna todas as bases de emergência (GET simples)
        public async Task<List<BaseEmergenciaDTO>> GetAllAsync()
        {
            return await _context.BasesEmergencias
                .Select(b => new BaseEmergenciaDTO
                {
                    Id = b.Id,
                    Localizacao = b.Localizacao,
                    Email = b.Email,
                    Telefone = b.Telefone,
                    Descricao = b.Descricao,
                    Tipo = b.Tipo,
                })
                .ToListAsync();
        }

        // Retorna base de emergência detalhada com nomes das entidades relacionadas (GET detalhado)
        public async Task<BaseEmergenciaDetailDTO?> GetDetailByIdAsync(int id)
        {
            var baseEmergencia = await _context.BasesEmergencias
                .Include(b => b.Instituicao)
                .Include(b => b.EventoExtremo)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (baseEmergencia == null) return null;

            return new BaseEmergenciaDetailDTO
            {
                Id = baseEmergencia.Id,
                Localizacao = baseEmergencia.Localizacao,
                Email = baseEmergencia.Email,
                Telefone = baseEmergencia.Telefone,
                Descricao = baseEmergencia.Descricao,
                Tipo = baseEmergencia.Tipo,
                InstituicaoNome = baseEmergencia.Instituicao?.Nome,
                EventoExtremoTipo = baseEmergencia.EventoExtremo?.Tipo
            };
        }

        // Criação de base de emergência (POST)
        public async Task<BaseEmergencia> CreateAsync(CreateBaseEmergenciaDTO dto)
        {
            var baseEmergencia = new BaseEmergencia
            {
                Localizacao = dto.Localizacao,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Descricao = dto.Descricao,
                Tipo = dto.Tipo,
                InstituicaoId = dto.InstituicaoId,
                EventoExtremoId = dto.EventoExtremoId
            };

            _context.BasesEmergencias.Add(baseEmergencia);
            await _context.SaveChangesAsync();

            return baseEmergencia;
        }

        // Atualização de base de emergência (PUT)
        public async Task<BaseEmergencia?> UpdateAsync(UpdateBaseEmergenciaDTO dto)
        {
            var baseEmergencia = await _context.BasesEmergencias.FindAsync(dto.Id);
            if (baseEmergencia == null) return null;

            baseEmergencia.Localizacao = dto.Localizacao;
            baseEmergencia.Email = dto.Email;
            baseEmergencia.Telefone = dto.Telefone;
            baseEmergencia.Descricao = dto.Descricao;
            baseEmergencia.Tipo = dto.Tipo;
            baseEmergencia.InstituicaoId = dto.InstituicaoId;
            baseEmergencia.EventoExtremoId = dto.EventoExtremoId;

            await _context.SaveChangesAsync();
            return baseEmergencia;
        }

        // Remoção de base de emergência (DELETE)
        public async Task<bool> DeleteAsync(int id)
        {
            var baseEmergencia = await _context.BasesEmergencias.FindAsync(id);
            if (baseEmergencia == null) return false;

            _context.BasesEmergencias.Remove(baseEmergencia);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
