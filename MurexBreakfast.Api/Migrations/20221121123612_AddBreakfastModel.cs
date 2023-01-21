using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MurexBreakfast.Api.Migrations
{
    public partial class AddBreakfastModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakfasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Savory = table.Column<List<string>>(type: "text[]", nullable: false),
                    Sweet = table.Column<List<string>>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfasts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "9e3197e5-ed9d-4066-ad59-0960cde1af5c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "259bc39c-2cd8-4bd5-8ab7-e0feeecac58a", "AQAAAAEAACcQAAAAEIB6YEDgOvD71irdLhOWY0coAho7uxFFljUQnK6q3tx7R+bYlUbc86iHbQlDM5J5Xg==", "5298a902-25a7-4717-b96b-34750fade73b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breakfasts");

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
    }
}
