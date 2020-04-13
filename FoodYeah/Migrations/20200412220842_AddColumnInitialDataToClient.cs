using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTodo.Migrations
{
    public partial class AddColumnInitialDataToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientNumber",
                table: "Clients",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "ClientNumber", "Name" },
                values: new object[] { 1, "1000000001", "Henry Antonio Mendoza Puerta" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "ClientNumber", "Name" },
                values: new object[] { 2, "1000000002", "Juan Perez Mendez" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ClientNumber",
                table: "Clients");
        }
    }
}
