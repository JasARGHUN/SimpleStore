using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTemplate_1.Migrations
{
    public partial class T4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppHomeImage",
                table: "Infos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppHomeText",
                table: "Infos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppHomeImage",
                table: "Infos");

            migrationBuilder.DropColumn(
                name: "AppHomeText",
                table: "Infos");
        }
    }
}
