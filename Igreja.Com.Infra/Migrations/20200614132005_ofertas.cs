using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class ofertas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferta_Culto_TipoCultoId",
                table: "Oferta");

            migrationBuilder.DropIndex(
                name: "IX_Oferta_TipoCultoId",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "TipoCultoId",
                table: "Oferta");

            migrationBuilder.AddColumn<int>(
                name: "CultoId",
                table: "Oferta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_CultoId",
                table: "Oferta",
                column: "CultoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oferta_Culto_CultoId",
                table: "Oferta",
                column: "CultoId",
                principalTable: "Culto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferta_Culto_CultoId",
                table: "Oferta");

            migrationBuilder.DropIndex(
                name: "IX_Oferta_CultoId",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "CultoId",
                table: "Oferta");

            migrationBuilder.AddColumn<int>(
                name: "TipoCultoId",
                table: "Oferta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_TipoCultoId",
                table: "Oferta",
                column: "TipoCultoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oferta_Culto_TipoCultoId",
                table: "Oferta",
                column: "TipoCultoId",
                principalTable: "Culto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
