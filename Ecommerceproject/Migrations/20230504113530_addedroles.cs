using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerceproject.Migrations
{
    /// <inheritdoc />
    public partial class addedroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecda2c9f-13cd-4e8f-bdbb-76107775dd61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a368ac98-666b-4062-bbad-b52a1ee78930", null, "Admin", "ADMIN" },
                    { "c76c15fd-ae37-4d2b-b6cd-0c631fd0f08b", null, "Manager", "MANAGER" },
                    { "ce7631be-7988-45d4-9d2a-22112859ba96", null, "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a368ac98-666b-4062-bbad-b52a1ee78930");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76c15fd-ae37-4d2b-b6cd-0c631fd0f08b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce7631be-7988-45d4-9d2a-22112859ba96");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ecda2c9f-13cd-4e8f-bdbb-76107775dd61", null, "System Administrator", "SYSTEMADMINISTRATOR" });
        }
    }
}
