using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class subIgrejas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IgrejasId",
                table: "Igrejas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Igrejas_IgrejasId",
                table: "Igrejas",
                column: "IgrejasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Igrejas_Igrejas_IgrejasId",
                table: "Igrejas",
                column: "IgrejasId",
                principalTable: "Igrejas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Igrejas_Igrejas_IgrejasId",
                table: "Igrejas");

            migrationBuilder.DropIndex(
                name: "IX_Igrejas_IgrejasId",
                table: "Igrejas");

            migrationBuilder.DropColumn(
                name: "IgrejasId",
                table: "Igrejas");
        }
    }
}
