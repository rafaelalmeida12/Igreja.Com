using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class caixa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Oferta",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    ofertaId = table.Column<int>(nullable: true),
                    despesaId = table.Column<int>(nullable: true),
                    Saldo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caixa_Despesa_despesaId",
                        column: x => x.despesaId,
                        principalTable: "Despesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Caixa_Oferta_ofertaId",
                        column: x => x.ofertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caixa_despesaId",
                table: "Caixa",
                column: "despesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Caixa_ofertaId",
                table: "Caixa",
                column: "ofertaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caixa");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Oferta");
        }
    }
}
