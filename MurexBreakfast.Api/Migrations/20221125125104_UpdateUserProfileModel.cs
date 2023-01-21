using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MurexBreakfast.Api.Migrations
{
    public partial class UpdateUserProfileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Age",
                table: "UserProfiles",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "UserProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HighestQualification",
                table: "UserProfiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Postion",
                table: "UserProfiles",
                type: "text",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "HighestQualification",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Postion",
                table: "UserProfiles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "753aa227-01e9-45d6-a25a-3c6cd5f754ec");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c6e55db-a9cb-436f-ab0e-a94460075ba0", "AQAAAAEAACcQAAAAEFMxa3N6z2EjI2AOJzrevJIbjVqw4+VUgeHuVtIN7y6fLlF/GI5gQlUriggDzOAPCw==", "b4bd0195-c050-4ec4-bc93-bb7c4661bc32" });
        }
    }
}
