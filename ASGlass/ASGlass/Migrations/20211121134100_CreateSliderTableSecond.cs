using Microsoft.EntityFrameworkCore.Migrations;

namespace ASGlass.Migrations
{
    public partial class CreateSliderTableSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(nullable: false),
                    Image = table.Column<string>(maxLength: 150, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    SubTitle = table.Column<string>(maxLength: 250, nullable: false),
                    RedirectUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}
