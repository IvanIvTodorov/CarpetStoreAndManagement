using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class rawMaterialSeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "899ac3de-0fd1-4354-87c7-71a66e26cc88", "AQAAAAEAACcQAAAAEDp3pqieChA0dULkus9aIM2yLo/bCVVYA3xaLk68lVWdTl5t9HDS/HdB0uhxEQ/f0w==" });

            migrationBuilder.UpdateData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 2 },
                column: "Quantity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 3 },
                column: "Quantity",
                value: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb0221f5-3817-494c-9a26-a1e9a35a5b40", "AQAAAAEAACcQAAAAEFcezTLgc6VkamCmEjpDfqiduwSag4O2uAvUqKA7Semeb57XomEBSVmfKeNctE+dgQ==" });

            migrationBuilder.UpdateData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 2 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 3 },
                column: "Quantity",
                value: 0);
        }
    }
}
