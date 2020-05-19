using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class categoriaofertaaIDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaOfertaId",
                table: "Oferta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_CategoriaOfertaId",
                table: "Oferta",
                column: "CategoriaOfertaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oferta_categoriaOferta_CategoriaOfertaId",
                table: "Oferta",
                column: "CategoriaOfertaId",
                principalTable: "categoriaOferta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oferta_categoriaOferta_CategoriaOfertaId",
                table: "Oferta");

            migrationBuilder.DropIndex(
                name: "IX_Oferta_CategoriaOfertaId",
                table: "Oferta");

            migrationBuilder.DropColumn(
                name: "CategoriaOfertaId",
                table: "Oferta");
        }
    }
}
