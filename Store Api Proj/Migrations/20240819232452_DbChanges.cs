using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Api_Proj.Migrations
{
    /// <inheritdoc />
    public partial class DbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsProducts_Orders_OrderId",
                table: "ProductsProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsProducts_Products_ProductId",
                table: "ProductsProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsProducts",
                table: "ProductsProducts");

            migrationBuilder.RenameTable(
                name: "ProductsProducts",
                newName: "OrderProducts");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsProducts_ProductId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Orders_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_Products_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                newName: "ProductsProducts");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductId",
                table: "ProductsProducts",
                newName: "IX_ProductsProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsProducts",
                table: "ProductsProducts",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsProducts_Orders_OrderId",
                table: "ProductsProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsProducts_Products_ProductId",
                table: "ProductsProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
