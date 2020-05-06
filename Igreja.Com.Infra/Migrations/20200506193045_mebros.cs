using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class mebros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Igrejas_IgrejasId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_IgrejasId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "IgrejasId",
                table: "Membro");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "Membro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Membro_IgrejaId",
                table: "Membro",
                column: "IgrejaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Igrejas_IgrejaId",
                table: "Membro",
                column: "IgrejaId",
                principalTable: "Igrejas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Membro_Igrejas_IgrejaId",
                table: "Membro");

            migrationBuilder.DropIndex(
                name: "IX_Membro_IgrejaId",
                table: "Membro");

            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "Membro");

            migrationBuilder.AddColumn<int>(
                name: "IgrejasId",
                table: "Membro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Membro_IgrejasId",
                table: "Membro",
                column: "IgrejasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Membro_Igrejas_IgrejasId",
                table: "Membro",
                column: "IgrejasId",
                principalTable: "Igrejas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
