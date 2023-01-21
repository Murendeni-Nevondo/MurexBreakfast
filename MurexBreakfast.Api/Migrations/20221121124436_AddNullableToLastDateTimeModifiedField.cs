using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MurexBreakfast.Api.Migrations
{
    public partial class AddNullableToLastDateTimeModifiedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "Breakfasts",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "c5329d46-e38f-4f14-ada7-10a9c45b3669");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "195e8459-9b96-4ecb-b9a0-312a6b1086ff", "AQAAAAEAACcQAAAAEGBw8EnHnamrxemt5TwB4dtefF/w0K98/8i43il5s5Df3hIm0LN8yoVcGZcE9UTTtA==", "218187b4-8200-4362-af5f-70b05485d250" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "Breakfasts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role",
                column: "ConcurrencyStamp",
                value: "c89aa64f-d10a-4bdb-92a5-7464e1f8cc10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a37e963-fff8-40c7-897a-9d843d56ac94", "AQAAAAEAACcQAAAAEA4o0UQ1RyLbAQg8tHxxWgs0NYrR8bivB6DfkIfMIxZQ0r0eAq2iWOIGtqxFTKeqIQ==", "8c10c776-da02-497e-b8e4-c41a7b15b361" });
        }
    }
}
