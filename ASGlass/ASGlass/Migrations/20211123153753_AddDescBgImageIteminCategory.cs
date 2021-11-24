using Microsoft.EntityFrameworkCore.Migrations;

namespace ASGlass.Migrations
{
    public partial class AddDescBgImageIteminCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BgImage",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Categories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BgImage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Categories");
        }
    }
}
