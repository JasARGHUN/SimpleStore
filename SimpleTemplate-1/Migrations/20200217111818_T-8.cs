using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTemplate_1.Migrations
{
    public partial class T8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AppHomeText2",
                table: "Infos",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppHomeSlideText1",
                table: "Infos",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppHomeSlideText2",
                table: "Infos",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppHomeSlideText3",
                table: "Infos",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppHomeSlideText1",
                table: "Infos");

            migrationBuilder.DropColumn(
                name: "AppHomeSlideText2",
                table: "Infos");

            migrationBuilder.DropColumn(
                name: "AppHomeSlideText3",
                table: "Infos");

            migrationBuilder.AlterColumn<string>(
                name: "AppHomeText2",
                table: "Infos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
