using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerceproject.Migrations
{
    /// <inheritdoc />
    public partial class NameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UsersUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_UserId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "Orders",
                newName: "UserPersonId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Orders",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UsersUserId",
                table: "Orders",
                newName: "IX_Orders_UserPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserPersonId",
                table: "Orders",
                column: "UserPersonId",
                principalTable: "Users",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserPersonId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_PersonId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UserPersonId",
                table: "Orders",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserPersonId",
                table: "Orders",
                newName: "IX_Orders_UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UsersUserId",
                table: "Orders",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
