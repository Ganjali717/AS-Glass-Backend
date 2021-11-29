using Microsoft.EntityFrameworkCore.Migrations;

namespace ASGlass.Migrations
{
    public partial class AddSomeItemsInAccessory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Accessories",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscountPrice",
                table: "Accessories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Accessories",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Accessories");
        }
    }
}
