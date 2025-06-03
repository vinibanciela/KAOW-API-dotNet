using Microsoft.EntityFrameworkCore;
using KAOW.Models;

namespace KAOW.Data
{
    public class CrisisDbContext : DbContext
    {
        public CrisisDbContext(DbContextOptions<CrisisDbContext> options) : base(options)
        {
        }

        // DbSets - Mapeamento das entidades
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<EventoExtremo> EventosExtremos { get; set; }
        public DbSet<BaseEmergencia> BasesEmergencias { get; set; }
        public DbSet<EventoInstituicao> EventoInstituicoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar chave composta para a tabela associativa EventoInstituicao
            modelBuilder.Entity<EventoInstituicao>()
                .HasKey(ei => new { ei.EventoExtremoId, ei.InstituicaoId });

            // Configurar relacionamentos N:N com tabela associativa
            modelBuilder.Entity<EventoInstituicao>()
                .HasOne(ei => ei.EventoExtremo)
                .WithMany(e => e.EventoInstituicoes)
                .HasForeignKey(ei => ei.EventoExtremoId);

            modelBuilder.Entity<EventoInstituicao>()
                .HasOne(ei => ei.Instituicao)
                .WithMany(i => i.EventoInstituicoes)
                .HasForeignKey(ei => ei.InstituicaoId);

            // Configurar relacionamentos 1:N opcionais
            modelBuilder.Entity<BaseEmergencia>()
                .HasOne(be => be.Instituicao)
                .WithMany(i => i.BasesEmergencia)
                .HasForeignKey(be => be.InstituicaoId)
                .OnDelete(DeleteBehavior.SetNull); // Permitir InstituicaoId null

            modelBuilder.Entity<BaseEmergencia>()
                .HasOne(be => be.EventoExtremo)
                .WithMany(e => e.BasesEmergencia)
                .HasForeignKey(be => be.EventoExtremoId)
                .OnDelete(DeleteBehavior.SetNull); // Permitir EventoExtremoId null
        }
    }
}
