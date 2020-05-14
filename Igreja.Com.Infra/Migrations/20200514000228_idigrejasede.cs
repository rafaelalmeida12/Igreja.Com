using Microsoft.EntityFrameworkCore.Migrations;

namespace Igreja.Com.Infra.Migrations
{
    public partial class idigrejasede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IgrejaSede",
                table: "Membro",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IgrejaSede",
                table: "Membro");
        }
    }
}
