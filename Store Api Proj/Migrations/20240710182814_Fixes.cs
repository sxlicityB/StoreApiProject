using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Api_Proj.Migrations
{
    /// <inheritdoc />
    public partial class Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Buyers_NameBuyerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "NameBuyerId",
                table: "Orders",
                newName: "BuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_NameBuyerId",
                table: "Orders",
                newName: "IX_Orders_BuyerId");

            migrationBuilder.RenameColumn(
                name: "Names",
                table: "Buyers",
                newName: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Buyers_BuyerId",
                table: "Orders",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "BuyerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Buyers_BuyerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Orders",
                newName: "NameBuyerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                newName: "IX_Orders_NameBuyerId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Buyers",
                newName: "Names");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Buyers_NameBuyerId",
                table: "Orders",
                column: "NameBuyerId",
                principalTable: "Buyers",
                principalColumn: "BuyerId");
        }
    }
}
