using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStoreProject.Migrations
{
    public partial class UpdateProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopBasketRows_ProductId",
                table: "ShopBasketRows");

            migrationBuilder.CreateIndex(
                name: "IX_ShopBasketRows_ProductId",
                table: "ShopBasketRows",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShopBasketRows_ProductId",
                table: "ShopBasketRows");

            migrationBuilder.CreateIndex(
                name: "IX_ShopBasketRows_ProductId",
                table: "ShopBasketRows",
                column: "ProductId",
                unique: true);
        }
    }
}
