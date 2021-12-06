using Microsoft.EntityFrameworkCore.Migrations;

namespace ASGlass.Migrations
{
    public partial class AddSomeItemsInProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Diametr",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "En",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Uzunluq",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diametr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "En",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Uzunluq",
                table: "Products");
        }
    }
}
