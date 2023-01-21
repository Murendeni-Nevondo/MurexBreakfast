using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MurexBreakfast.Api.Migrations
{
    public partial class AddProfileImgUrlToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImgUrl",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "1325915a-5576-4a0f-a956-775c1752a319");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e1777ec-2c09-41de-885b-1461e430d959", "AQAAAAEAACcQAAAAEEndEukLVcjYLGNIaU+wCYUbbR6BJ4NZcRgfEhJdRQtQspH0zEp5i+qNyVQ7ahIpDA==", "4f9b3284-582b-4faf-a89c-ee1f551c8cbc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImgUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "45475b08-750d-4ed6-a8c7-dbd4e2edee4c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfd7d3c4-b298-4671-a578-e39714037a60", "AQAAAAEAACcQAAAAEIimCsMyvlyxDgI5Ff/elkRwFRxMrnbgNlk4iq67n/9RJ7QjKFSgHne3N0JCKAB9Hg==", "fae15ce7-abaf-4fba-af8b-2bd03bd386e9" });
        }
    }
}
