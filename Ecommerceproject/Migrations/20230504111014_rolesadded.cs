using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerceproject.Migrations
{
    /// <inheritdoc />
    public partial class rolesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ecda2c9f-13cd-4e8f-bdbb-76107775dd61", null, "System Administrator", "SYSTEMADMINISTRATOR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecda2c9f-13cd-4e8f-bdbb-76107775dd61");
        }
    }
}
