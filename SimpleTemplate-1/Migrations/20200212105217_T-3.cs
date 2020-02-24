using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTemplate_1.Migrations
{
    public partial class T3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    InfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(nullable: false),
                    AppAddress = table.Column<string>(nullable: false),
                    AppPhone1 = table.Column<string>(nullable: false),
                    AppPhone2 = table.Column<string>(nullable: false),
                    AppImage = table.Column<string>(nullable: true),
                    AppSocialImg = table.Column<string>(nullable: true),
                    AppSocialAddress = table.Column<string>(nullable: true),
                    AppBackgroundImage = table.Column<string>(nullable: true),
                    AppEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.InfoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Infos");
        }
    }
}
