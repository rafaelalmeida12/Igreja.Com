﻿using Igreja.Com.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igreja.Com.Infra.Configuracao
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Membro> Membro { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Igrejas> Igrejas { get; set; }
        public DbSet<Culto> Culto { get; set; }
        public DbSet<CategoriaCulto> CategoriaCulto { get; set; }
        //Financeiro
        public DbSet<Despesa> Despesa { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<Oferta> Oferta { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DbSet<Dizimo> Dizimo { get; set; }
        public DbSet<CategoriaDespesa> categoriaDespesas { get; set; }
        public DbSet<CategoriaOferta> categoriaOferta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbNOVO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Endereco>()
                .Property<int>("MembroId");

            modelBuilder
                 .Entity<Endereco>()
                 .HasKey("MembroId");

            base.OnModelCreating(modelBuilder);
        }
    }
}
