using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class TESTE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Culto_CategoriaCulto_CategoriaCultoId",
                table: "Culto");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaCultoId",
                table: "Culto",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Culto_CategoriaCulto_CategoriaCultoId",
                table: "Culto",
                column: "CategoriaCultoId",
                principalTable: "CategoriaCulto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Culto_CategoriaCulto_CategoriaCultoId",
                table: "Culto");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaCultoId",
                table: "Culto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Culto_CategoriaCulto_CategoriaCultoId",
                table: "Culto",
                column: "CategoriaCultoId",
                principalTable: "CategoriaCulto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
