using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MurexBreakfast.Api.Migrations
{
    public partial class AddHostToBreakfastModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HostId",
                table: "Breakfasts",
                type: "text",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Breakfasts_HostId",
                table: "Breakfasts",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breakfasts_AspNetUsers_HostId",
                table: "Breakfasts",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breakfasts_AspNetUsers_HostId",
                table: "Breakfasts");

            migrationBuilder.DropIndex(
                name: "IX_Breakfasts_HostId",
                table: "Breakfasts");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "Breakfasts");

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
    }
}
