using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class Cargoss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembroId",
                table: "Cargo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cargo_MembroId",
                table: "Cargo",
                column: "MembroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargo_Membro_MembroId",
                table: "Cargo",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargo_Membro_MembroId",
                table: "Cargo");

            migrationBuilder.DropIndex(
                name: "IX_Cargo_MembroId",
                table: "Cargo");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Cargo");
        }
    }
}
