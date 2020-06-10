using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class tbmovimentacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_Culto_CultoId",
                table: "Movimentacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacao_categoriaDespesas_categoriaDespesaId",
                table: "Movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacao_CultoId",
                table: "Movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_Movimentacao_categoriaDespesaId",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "CultoId",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "categoriaDespesaId",
                table: "Movimentacao");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Movimentacao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id_Movimentacoes",
                table: "Movimentacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pessoa",
                table: "Movimentacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDespesa",
                table: "Movimentacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Movimentacao",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "Id_Movimentacoes",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "Pessoa",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "TipoDespesa",
                table: "Movimentacao");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Movimentacao");

            migrationBuilder.AddColumn<int>(
                name: "CultoId",
                table: "Movimentacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categoriaDespesaId",
                table: "Movimentacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_CultoId",
                table: "Movimentacao",
                column: "CultoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_categoriaDespesaId",
                table: "Movimentacao",
                column: "categoriaDespesaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacao_Culto_CultoId",
                table: "Movimentacao",
                column: "CultoId",
                principalTable: "Culto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacao_categoriaDespesas_categoriaDespesaId",
                table: "Movimentacao",
                column: "categoriaDespesaId",
                principalTable: "categoriaDespesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
