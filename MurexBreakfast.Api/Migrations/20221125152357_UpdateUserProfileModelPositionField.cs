using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MurexBreakfast.Api.Migrations
{
    public partial class UpdateUserProfileModelPositionField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Postion",
                table: "UserProfiles",
                newName: "Position");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "6b70af79-b7f7-4ede-a3f7-7c1e52efcb51");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42a0dc85-edc5-4eb6-977f-1d2a67f0aa16", "AQAAAAEAACcQAAAAEJfiFaO/KA95Vx5f1pQzVwrON6n+6B0XajrLZWBSN6OALyklG91vJqnrZ4knS2KXkQ==", "45719d01-770f-4085-a7a5-73cc6735f56d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "UserProfiles",
                newName: "Postion");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "b533831f-4ff3-4973-ba29-e38fb841ee27");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a70a1a4b-1b55-4b25-b782-49cc81be6b7c", "AQAAAAEAACcQAAAAEKolmnjIaVn/3oVBT/FZGy9jHtXt8xp5Z0E/hcjwGm5WnAss26I6HFJqaob+oVd6zQ==", "44eab798-7822-4e71-985b-f3b6083b453e" });
        }
    }
}
