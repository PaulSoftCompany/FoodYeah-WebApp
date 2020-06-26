using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodYeah.Migrations
{
    public partial class UserAndCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f858f41-e5e2-4ddb-86a9-39ee04f5f62d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb029378-8fe8-474a-92c4-13446510ff7d");

            migrationBuilder.DropColumn(
                name: "CustomerAge",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ed14d414-2e1e-45af-9d01-0ab0330352f5", "95c2a6db-959b-49f0-abd1-ba288545fbfb", "ADMIN", "ADMIN" },
                    { "0e522ab4-cef7-4d0a-ab7b-ac85256506e8", "b25aac5f-0dae-4587-8731-35da556e425f", "USER", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Customer_Categories",
                columns: new[] { "Customer_CategoryId", "Customer_CategoryDescription", "Customer_CategoryName" },
                values: new object[,]
                {
                    { 1, "ADMIN", "ADMIN" },
                    { 2, "USER", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Customers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CustomerId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e522ab4-cef7-4d0a-ab7b-ac85256506e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed14d414-2e1e-45af-9d01-0ab0330352f5");

            migrationBuilder.DeleteData(
                table: "Customer_Categories",
                keyColumn: "Customer_CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer_Categories",
                keyColumn: "Customer_CategoryId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte>(
                name: "CustomerAge",
                table: "Customers",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7f858f41-e5e2-4ddb-86a9-39ee04f5f62d", "7ed6ab38-9e9f-46c9-826c-1025e0720d38", "Admin", "ADMIN" },
                    { "fb029378-8fe8-474a-92c4-13446510ff7d", "6c1c5f42-061c-4c11-954e-e7497f592b8d", "User", "USER" }
                });
        }
    }
}
