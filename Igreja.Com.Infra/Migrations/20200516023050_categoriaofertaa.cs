using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class categoriaofertaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Culto_Membro_DirigenteId",
                table: "Culto");

            migrationBuilder.DropIndex(
                name: "IX_Culto_DirigenteId",
                table: "Culto");

            migrationBuilder.DropColumn(
                name: "DirigenteId",
                table: "Culto");

            migrationBuilder.AddColumn<int>(
                name: "MembroId",
                table: "Culto",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categoriaOferta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaOferta", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Culto_MembroId",
                table: "Culto",
                column: "MembroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Culto_Membro_MembroId",
                table: "Culto",
                column: "MembroId",
                principalTable: "Membro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Culto_Membro_MembroId",
                table: "Culto");

            migrationBuilder.DropTable(
                name: "categoriaOferta");

            migrationBuilder.DropIndex(
                name: "IX_Culto_MembroId",
                table: "Culto");

            migrationBuilder.DropColumn(
                name: "MembroId",
                table: "Culto");

            migrationBuilder.AddColumn<int>(
                name: "DirigenteId",
                table: "Culto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Culto_DirigenteId",
                table: "Culto",
                column: "DirigenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Culto_Membro_DirigenteId",
                table: "Culto",
                column: "DirigenteId",
                principalTable: "Membro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
