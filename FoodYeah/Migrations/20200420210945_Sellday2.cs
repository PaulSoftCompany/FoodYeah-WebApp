using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class Sellday2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellDay",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SellDay",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
