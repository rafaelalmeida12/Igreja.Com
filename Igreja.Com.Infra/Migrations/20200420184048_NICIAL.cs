using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class NICIAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Culto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culto", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_DadosMinisteriais_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    DadosMinisteriaisId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_DadosMinisteriais_CargoId",
                table: "DadosMinisteriais",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dizimo_CultoId",
                table: "Dizimo",
                column: "CultoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dizimo_MembroId",
                table: "Dizimo",
                column: "MembroId");

            migrationBuilder.CreateIndex(
                name: "IX_Membro_DadosMinisteriaisId",
                table: "Membro",
                column: "DadosMinisteriaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dizimo");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Culto");

            migrationBuilder.DropTable(
                name: "Membro");

            migrationBuilder.DropTable(
                name: "DadosMinisteriais");

            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
