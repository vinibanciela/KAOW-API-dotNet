﻿// <auto-generated />
using System;
using KAOW.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KAOW.Data.Migrations
{
    [DbContext(typeof(CrisisDbContext))]
    partial class CrisisDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KAOW.Models.BaseEmergencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EventoExtremoId")
                        .HasColumnType("integer");

                    b.Property<int?>("InstituicaoId")
                        .HasColumnType("integer");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventoExtremoId");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("BasesEmergencias");
                });

            modelBuilder.Entity("KAOW.Models.EventoExtremo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EventosExtremos");
                });

            modelBuilder.Entity("KAOW.Models.EventoInstituicao", b =>
                {
                    b.Property<int>("EventoExtremoId")
                        .HasColumnType("integer");

                    b.Property<int>("InstituicaoId")
                        .HasColumnType("integer");

                    b.HasKey("EventoExtremoId", "InstituicaoId");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("EventoInstituicoes");
                });

            modelBuilder.Entity("KAOW.Models.Instituicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("KAOW.Models.BaseEmergencia", b =>
                {
                    b.HasOne("KAOW.Models.EventoExtremo", "EventoExtremo")
                        .WithMany("BasesEmergencia")
                        .HasForeignKey("EventoExtremoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("KAOW.Models.Instituicao", "Instituicao")
                        .WithMany("BasesEmergencia")
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("EventoExtremo");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("KAOW.Models.EventoInstituicao", b =>
                {
                    b.HasOne("KAOW.Models.EventoExtremo", "EventoExtremo")
                        .WithMany("EventoInstituicoes")
                        .HasForeignKey("EventoExtremoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KAOW.Models.Instituicao", "Instituicao")
                        .WithMany("EventoInstituicoes")
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventoExtremo");

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("KAOW.Models.EventoExtremo", b =>
                {
                    b.Navigation("BasesEmergencia");

                    b.Navigation("EventoInstituicoes");
                });

            modelBuilder.Entity("KAOW.Models.Instituicao", b =>
                {
                    b.Navigation("BasesEmergencia");

                    b.Navigation("EventoInstituicoes");
                });
#pragma warning restore 612, 618
        }
    }
}
