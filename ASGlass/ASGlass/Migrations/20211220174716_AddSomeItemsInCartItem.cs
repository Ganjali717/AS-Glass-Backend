using Microsoft.EntityFrameworkCore.Migrations;

namespace ASGlass.Migrations
{
    public partial class AddSomeItemsInCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Corner",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Diametr",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscountPrice",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "En",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAccessory",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Polish",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CartItems",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Shape",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Thickness",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Uzunluq",
                table: "CartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Corner",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Diametr",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "En",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "IsAccessory",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Polish",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Shape",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Thickness",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Uzunluq",
                table: "CartItems");
        }
    }
}
