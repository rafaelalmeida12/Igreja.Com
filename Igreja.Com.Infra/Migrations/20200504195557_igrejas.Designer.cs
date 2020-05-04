﻿// <auto-generated />
using System;
using Igreja.Com.Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Igreja.Com.Infra.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200504195557_igrejas")]
    partial class igrejas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Caixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("despesaId")
                        .HasColumnType("int");

                    b.Property<int?>("ofertaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("despesaId");

                    b.HasIndex("ofertaId");

                    b.ToTable("Caixa");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MembroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MembroId");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Culto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Culto");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.DadosMinisteriais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("ComoConverteu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataBatismo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataConversao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataMembrado")
                        .HasColumnType("datetime2");

                    b.Property<string>("IgrejaProcedencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoAdesao")
                        .HasColumnType("int");

                    b.Property<int>("TipoBatizado")
                        .HasColumnType("int");

                    b.Property<int>("TipoDizimista")
                        .HasColumnType("int");

                    b.Property<int>("TipoFuncaoExerce")
                        .HasColumnType("int");

                    b.Property<int>("TipoSituacao")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.ToTable("DadosMinisteriais");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Despesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DestinoDespesa")
                        .HasColumnType("int");

                    b.Property<string>("NumeroNotaFiscal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoDespesa")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Despesa");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Dizimo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CultoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormaPagamento")
                        .HasColumnType("int");

                    b.Property<int>("MembroId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CultoId");

                    b.HasIndex("MembroId");

                    b.ToTable("Dizimo");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Endereco", b =>
                {
                    b.Property<int>("MembroId")
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MembroId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Igrejas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Igrejas");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Membro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Curso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DadosMinisteriaisId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Escolaridade")
                        .HasColumnType("int");

                    b.Property<int>("EstadoCivil")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profissão")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DadosMinisteriaisId");

                    b.ToTable("Membro");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TipoCultoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TipoCultoId");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Caixa", b =>
                {
                    b.HasOne("Igreja.Com.Dominio.Entidades.Despesa", "despesa")
                        .WithMany()
                        .HasForeignKey("despesaId");

                    b.HasOne("Igreja.Com.Dominio.Entidades.Oferta", "oferta")
                        .WithMany()
                        .HasForeignKey("ofertaId");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Cargo", b =>
                {
                    b.HasOne("Igreja.Com.Dominio.Entidades.Membro", null)
                        .WithMany("Cargos")
                        .HasForeignKey("MembroId");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.DadosMinisteriais", b =>
                {
                    b.HasOne("Igreja.Com.Dominio.Entidades.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Dizimo", b =>
                {
                    b.HasOne("Igreja.Com.Dominio.Entidades.Culto", "Culto")
                        .WithMany()
                        .HasForeignKey("CultoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Igreja.Com.Dominio.Entidades.Membro", "Membro")
                        .WithMany()
                        .HasForeignKey("MembroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Endereco", b =>
                {
                    b.HasOne("Igreja.Com.Dominio.Entidades.Membro", null)
                        .WithOne("Endereco")
                        .HasForeignKey("Igreja.Com.Dominio.Entidades.Endereco", "MembroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Membro", b =>
                {
                    b.HasOne("Igreja.Com.Dominio.Entidades.DadosMinisteriais", "DadosMinisteriais")
                        .WithMany()
                        .HasForeignKey("DadosMinisteriaisId");
                });

            modelBuilder.Entity("Igreja.Com.Dominio.Entidades.Oferta", b =>
                {
                    b.HasOne("Igreja.Com.Dominio.Entidades.Culto", "TipoCulto")
                        .WithMany()
                        .HasForeignKey("TipoCultoId");
                });
#pragma warning restore 612, 618
        }
    }
}
