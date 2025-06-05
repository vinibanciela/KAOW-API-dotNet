using KAOW.DTOs;
using KAOW.Models;
using KAOW.Data;
using Microsoft.EntityFrameworkCore;

namespace KAOW.Services
{
    public class InstituicaoService
    {
        private readonly CrisisDbContext _context;

        public InstituicaoService(CrisisDbContext context)
        {
            _context = context;
        }

        // Retorna todas as instituições (GET simples)
        public async Task<List<InstituicaoDTO>> GetAllAsync()
        {
            return await _context.Instituicoes
                .Select(i => new InstituicaoDTO
                {
                    Id = i.Id,
                    Nome = i.Nome,
                    Tipo = i.Tipo,
                    Email = i.Email,
                    CNPJ = i.CNPJ,
                    Telefone = i.Telefone,
                    Endereco = i.Endereco,
                    Descricao = i.Descricao
                })
                .ToListAsync();
        }

        // Retorna uma instituição detalhada com relacionamentos (GET detalhado)
        public async Task<InstituicaoDetailDTO?> GetDetailByIdAsync(int id)
        {
            var instituicao = await _context.Instituicoes
                .Include(i => i.BasesEmergencia)
                .Include(i => i.EventoInstituicoes)
                .ThenInclude(ei => ei.EventoExtremo) 
                .FirstOrDefaultAsync(i => i.Id == id);

            if (instituicao == null) return null;

            return new InstituicaoDetailDTO
            {
                Id = instituicao.Id,
                Nome = instituicao.Nome,
                Tipo = instituicao.Tipo,
                Email = instituicao.Email,
                CNPJ = instituicao.CNPJ,
                Telefone = instituicao.Telefone,
                Endereco = instituicao.Endereco,
                Descricao = instituicao.Descricao,
                BasesEmergencia = instituicao.BasesEmergencia
                    .Select(b => b.Localizacao)
                    .ToList(),

                EventosExtremos = instituicao.EventoInstituicoes
                    .Select(ei => ei.EventoExtremo.Tipo)
                    .ToList()
            };
        }

        // Criação de nova instituição (POST)
        public async Task<Instituicao> CreateAsync(CreateInstituicaoDTO dto)
        {
            var instituicao = new Instituicao
            {
                Nome = dto.Nome,
                Tipo = dto.Tipo,
                Email = dto.Email,
                CNPJ = dto.CNPJ,
                Telefone = dto.Telefone,
                Endereco = dto.Endereco,
                Descricao = dto.Descricao
            };

            _context.Instituicoes.Add(instituicao);
            await _context.SaveChangesAsync();

            return instituicao;
        }

        // Atualização de instituição (PUT)
        public async Task<Instituicao?> UpdateAsync(UpdateInstituicaoDTO dto)
        {
            var instituicao = await _context.Instituicoes.FindAsync(dto.Id);
            if (instituicao == null) return null;

            instituicao.Nome = dto.Nome;
            instituicao.Tipo = dto.Tipo;
            instituicao.Email = dto.Email;
            instituicao.CNPJ = dto.CNPJ;
            instituicao.Telefone = dto.Telefone;
            instituicao.Endereco = dto.Endereco;
            instituicao.Descricao = dto.Descricao;

            await _context.SaveChangesAsync();
            return instituicao;
        }

        // Remoção de instituição (DELETE)
        public async Task<bool> DeleteAsync(int id)
        {
            var instituicao = await _context.Instituicoes.FindAsync(id);
            if (instituicao == null) return false;

            _context.Instituicoes.Remove(instituicao);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
