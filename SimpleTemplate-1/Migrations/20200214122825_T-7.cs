using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTemplate_1.Migrations
{
    public partial class T7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppHomeText2",
                table: "Infos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppHomeText2",
                table: "Infos");
        }
    }
}
