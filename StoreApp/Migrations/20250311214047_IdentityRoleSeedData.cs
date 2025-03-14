using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "446813e9-f79b-4d38-83d2-72d88ab7a37a", null, "User", "USER" },
                    { "68f9097b-8ed7-4dc1-b01d-bdc2e2fc6641", null, "Admin", "ADMIN" },
                    { "aba3b729-b8fa-475e-8801-1ea1d52f4f76", null, "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "446813e9-f79b-4d38-83d2-72d88ab7a37a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68f9097b-8ed7-4dc1-b01d-bdc2e2fc6641");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aba3b729-b8fa-475e-8801-1ea1d52f4f76");
        }
    }
}
