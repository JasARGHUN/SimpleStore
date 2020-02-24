using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTemplate_1.Migrations
{
    public partial class T11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderTime",
                table: "CartLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTime",
                table: "CartLine");
        }
    }
}
