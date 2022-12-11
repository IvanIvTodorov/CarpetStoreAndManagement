using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class moreRawMaterialsToInventorySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43fef9b8-26e0-4ab1-8840-f21509d8387e", "AQAAAAEAACcQAAAAECa4Oeh6XI6ulnUjBh8+k/aoBr8S1VDL0axkMkqo49KDvktR6x5mqFHz6z4Pm7LsSQ==" });

            migrationBuilder.InsertData(
                table: "RawMaterials",
                columns: new[] { "Id", "ColorId", "Type" },
                values: new object[,]
                {
                    { 4, 5, 0 },
                    { 5, 5, 2 },
                    { 6, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "InventoryRawMaterials",
                columns: new[] { "InventoryId", "RawMaterialId", "Quantity" },
                values: new object[] { 1, 4, 20 });

            migrationBuilder.InsertData(
                table: "InventoryRawMaterials",
                columns: new[] { "InventoryId", "RawMaterialId", "Quantity" },
                values: new object[] { 1, 5, 20 });

            migrationBuilder.InsertData(
                table: "InventoryRawMaterials",
                columns: new[] { "InventoryId", "RawMaterialId", "Quantity" },
                values: new object[] { 1, 6, 20 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "RawMaterials",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RawMaterials",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RawMaterials",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "899ac3de-0fd1-4354-87c7-71a66e26cc88", "AQAAAAEAACcQAAAAEDp3pqieChA0dULkus9aIM2yLo/bCVVYA3xaLk68lVWdTl5t9HDS/HdB0uhxEQ/f0w==" });
        }
    }
}
