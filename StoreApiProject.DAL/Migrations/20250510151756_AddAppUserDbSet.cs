using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApiProject.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAppUserDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_AppUser_UserId",
                table: "Buyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser");

            migrationBuilder.RenameTable(
                name: "AppUser",
                newName: "AppUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_AppUsers_UserId",
                table: "Buyers",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_AppUsers_UserId",
                table: "Buyers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                newName: "AppUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUser",
                table: "AppUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_AppUser_UserId",
                table: "Buyers",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
