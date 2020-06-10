using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class cultos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Culto_CategoriaCulto_CategoriaCultoId",
                table: "Culto");

            migrationBuilder.DropForeignKey(
                name: "FK_Culto_Membro_MembroId",
                table: "Culto");

            migrationBuilder.DropTable(
                name: "CategoriaCulto");

            migrationBuilder.DropIndex(
                name: "IX_Culto_CategoriaCultoId",
                table: "Culto");

            migrationBuilder.DropIndex(
                name: "IX_Culto_MembroId",
                table: "Culto");

            migrationBuilder.DropColumn(
                name: "CategoriaCultoId",
                table: "Culto");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Culto");

            migrationBuilder.AddColumn<string>(
                name: "descricao",
                table: "Culto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricao",
                table: "Culto");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaCultoId",
                table: "Culto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MembroId",
                table: "Culto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaCulto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaCulto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Culto_CategoriaCultoId",
                table: "Culto",
                column: "CategoriaCultoId");

            migrationBuilder.CreateIndex(
                name: "IX_Culto_MembroId",
                table: "Culto",
                column: "MembroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Culto_CategoriaCulto_CategoriaCultoId",
                table: "Culto",
                column: "CategoriaCultoId",
                principalTable: "CategoriaCulto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Culto_Membro_MembroId",
                table: "Culto",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
