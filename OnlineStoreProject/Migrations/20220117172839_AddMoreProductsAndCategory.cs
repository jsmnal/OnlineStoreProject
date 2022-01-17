using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStoreProject.Migrations
{
    public partial class AddMoreProductsAndCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Pictures of beatifull finland", "Finland" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "DiscountId", "ImagePath", "Name", "Price", "StockQuantity", "Views" },
                values: new object[,]
                {
                    { 4, 2, new DateTime(2021, 12, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), "Picture of a beautifull Lapland", 1, "Lappi_1.jpg", "Lapland", 99.99m, 27, 0 },
                    { 5, 2, new DateTime(2021, 12, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), "Mountain of Finland", 1, "Lappi_2.jpg", "Lapland mountain", 19.99m, 22, 0 },
                    { 6, 2, new DateTime(2021, 12, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), "Forest of Finland", 1, "Lappi_3.jpg", "Lapland forest", 9.99m, 10, 0 },
                    { 7, 2, new DateTime(2021, 12, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), "Mountain of Finland", 1, "Lappi_4.jpg", "Lapland 1", 19.99m, 22, 0 },
                    { 8, 2, new DateTime(2021, 12, 2, 9, 30, 0, 0, DateTimeKind.Unspecified), "Mountain of Finland", 1, "Lappi_5.jpg", "Lapland 2", 19.99m, 22, 0 },
                    { 9, 2, new DateTime(2021, 12, 4, 9, 30, 0, 0, DateTimeKind.Unspecified), "Mountain of Finland", 1, "Lappi_6.jpg", "Lapland 3", 19.99m, 22, 0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "DiscountId", "ImagePath", "Name", "Price", "StockQuantity", "Views" },
                values: new object[] { 10, 3, new DateTime(2021, 11, 2, 9, 30, 0, 0, DateTimeKind.Unspecified), "Mountain of Finland", 1, "Lappi_7.jpg", "Lapland 4", 8.89m, 22, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "DiscountId", "ImagePath", "Name", "Price", "StockQuantity", "Views" },
                values: new object[] { 11, 3, new DateTime(2021, 11, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), "Mountain of Finland", 1, "Lappi_8.jpg", "Lapland 5", 20.00m, 22, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "DiscountId", "ImagePath", "Name", "Price", "StockQuantity", "Views" },
                values: new object[] { 12, 3, new DateTime(2021, 9, 2, 9, 30, 0, 0, DateTimeKind.Unspecified), "Mountain of Finland", 1, "Lappi_9.jpg", "Lapland 6", 89.99m, 22, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
