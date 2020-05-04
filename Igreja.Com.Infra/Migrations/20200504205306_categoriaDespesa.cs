using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class categoriaDespesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoDespesa",
                table: "Despesa");

            migrationBuilder.AddColumn<int>(
                name: "categoriaDespesaId",
                table: "Despesa",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaDespesa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaDespesa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Despesa_categoriaDespesaId",
                table: "Despesa",
                column: "categoriaDespesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesa_CategoriaDespesa_categoriaDespesaId",
                table: "Despesa",
                column: "categoriaDespesaId",
                principalTable: "CategoriaDespesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesa_CategoriaDespesa_categoriaDespesaId",
                table: "Despesa");

            migrationBuilder.DropTable(
                name: "CategoriaDespesa");

            migrationBuilder.DropIndex(
                name: "IX_Despesa_categoriaDespesaId",
                table: "Despesa");

            migrationBuilder.DropColumn(
                name: "categoriaDespesaId",
                table: "Despesa");

            migrationBuilder.AddColumn<int>(
                name: "TipoDespesa",
                table: "Despesa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
