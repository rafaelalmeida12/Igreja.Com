using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class inicialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaCulto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaCulto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoriaDespesas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaDespesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Igrejas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Rua = table.Column<string>(nullable: false),
                    Numero = table.Column<string>(nullable: false),
                    Bairro = table.Column<string>(nullable: false),
                    IgrejasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igrejas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Igrejas_Igrejas_IgrejasId",
                        column: x => x.IgrejasId,
                        principalTable: "Igrejas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Despesa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    NumeroNotaFiscal = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    categoriaDespesaId = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DestinoDespesa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Despesa_categoriaDespesas_categoriaDespesaId",
                        column: x => x.categoriaDespesaId,
                        principalTable: "categoriaDespesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DadosMinisteriais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    TipoSituacao = table.Column<int>(nullable: false),
                    CargoId = table.Column<int>(nullable: true),
                    DataBatismo = table.Column<DateTime>(nullable: false),
                    DataConversao = table.Column<DateTime>(nullable: false),
                    ComoConverteu = table.Column<string>(nullable: true),
                    IgrejaProcedencia = table.Column<string>(nullable: true),
                    DataMembrado = table.Column<DateTime>(nullable: false),
                    TipoBatizado = table.Column<int>(nullable: false),
                    TipoDizimista = table.Column<int>(nullable: false),
                    TipoAdesao = table.Column<int>(nullable: false),
                    TipoFuncaoExerce = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosMinisteriais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Membro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sexo = table.Column<int>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    EstadoCivil = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    Profissão = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Escolaridade = table.Column<int>(nullable: false),
                    Curso = table.Column<string>(nullable: true),
                    DadosMinisteriaisId = table.Column<int>(nullable: true),
                    CargoId = table.Column<int>(nullable: false),
                    IgrejaSede = table.Column<int>(nullable: true),
                    IgrejaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membro_DadosMinisteriais_DadosMinisteriaisId",
                        column: x => x.DadosMinisteriaisId,
                        principalTable: "DadosMinisteriais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Membro_Igrejas_IgrejaId",
                        column: x => x.IgrejaId,
                        principalTable: "Igrejas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    MembroId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cargo_Membro_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Culto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    CategoriaCultoId = table.Column<int>(nullable: true),
                    DirigenteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Culto_CategoriaCulto_CategoriaCultoId",
                        column: x => x.CategoriaCultoId,
                        principalTable: "CategoriaCulto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Culto_Membro_DirigenteId",
                        column: x => x.DirigenteId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    MembroId = table.Column<int>(nullable: false),
                    Rua = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.MembroId);
                    table.ForeignKey(
                        name: "FK_Endereco_Membro_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dizimo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    MembroId = table.Column<int>(nullable: false),
                    CultoId = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    FormaPagamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dizimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dizimo_Culto_CultoId",
                        column: x => x.CultoId,
                        principalTable: "Culto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dizimo_Membro_MembroId",
                        column: x => x.MembroId,
                        principalTable: "Membro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    categoriaDespesaId = table.Column<int>(nullable: true),
                    CultoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Culto_CultoId",
                        column: x => x.CultoId,
                        principalTable: "Culto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacao_categoriaDespesas_categoriaDespesaId",
                        column: x => x.categoriaDespesaId,
                        principalTable: "categoriaDespesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    TipoCultoId = table.Column<int>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Saldo = table.Column<decimal>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oferta_Culto_TipoCultoId",
                        column: x => x.TipoCultoId,
                        principalTable: "Culto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    MovimentacaoId = table.Column<int>(nullable: false),
                    SaldoAnterior = table.Column<decimal>(nullable: false),
                    SaldoAtual = table.Column<decimal>(nullable: false),
                    StatusCaixa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caixa_Movimentacao_MovimentacaoId",
                        column: x => x.MovimentacaoId,
                        principalTable: "Movimentacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caixa_MovimentacaoId",
                table: "Caixa",
                column: "MovimentacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_MembroId",
                table: "Cargo",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Culto_CategoriaCultoId",
                table: "Culto",
                column: "CategoriaCultoId");

            migrationBuilder.CreateIndex(
                name: "IX_Culto_DirigenteId",
                table: "Culto",
                column: "DirigenteId");

            migrationBuilder.CreateIndex(
                name: "IX_DadosMinisteriais_CargoId",
                table: "DadosMinisteriais",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_categoriaDespesaId",
                table: "Despesa",
                column: "categoriaDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dizimo_CultoId",
                table: "Dizimo",
                column: "CultoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dizimo_MembroId",
                table: "Dizimo",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Igrejas_IgrejasId",
                table: "Igrejas",
                column: "IgrejasId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_DadosMinisteriaisId",
                table: "Membro",
                column: "DadosMinisteriaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_IgrejaId",
                table: "Membro",
                column: "IgrejaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_CultoId",
                table: "Movimentacao",
                column: "CultoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_categoriaDespesaId",
                table: "Movimentacao",
                column: "categoriaDespesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_TipoCultoId",
                table: "Oferta",
                column: "TipoCultoId");

            migrationBuilder.AddForeignKey(
                name: "FK_DadosMinisteriais_Cargo_CargoId",
                table: "DadosMinisteriais",
                column: "CargoId",
                principalTable: "Cargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Membro_MembroId",
                table: "Cargo");

            migrationBuilder.DropTable(
                name: "Caixa");

            migrationBuilder.DropTable(
                name: "Despesa");

            migrationBuilder.DropTable(
                name: "Dizimo");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "Culto");

            migrationBuilder.DropTable(
                name: "categoriaDespesas");

            migrationBuilder.DropTable(
                name: "CategoriaCulto");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "DadosMinisteriais");

            migrationBuilder.DropTable(
                name: "Igrejas");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
