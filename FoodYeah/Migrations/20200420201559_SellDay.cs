using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class SellDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellDay",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellDay",
                table: "Products");
        }
    }
}
