using Microsoft.EntityFrameworkCore.Migrations;

namespace Flowers_Shop.Migrations
{
    public partial class Addpath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "PlayMusics",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "PlayMusics");
        }
    }
}
