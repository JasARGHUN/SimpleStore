using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTemplate_1.Migrations
{
    public partial class T6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarouselImage",
                table: "Infos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarouselImage2",
                table: "Infos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarouselImage3",
                table: "Infos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarouselImage",
                table: "Infos");

            migrationBuilder.DropColumn(
                name: "CarouselImage2",
                table: "Infos");

            migrationBuilder.DropColumn(
                name: "CarouselImage3",
                table: "Infos");
        }
    }
}
