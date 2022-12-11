using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class rawMaterialsSeedToInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb0221f5-3817-494c-9a26-a1e9a35a5b40", "AQAAAAEAACcQAAAAEFcezTLgc6VkamCmEjpDfqiduwSag4O2uAvUqKA7Semeb57XomEBSVmfKeNctE+dgQ==" });

            migrationBuilder.InsertData(
                table: "RawMaterials",
                columns: new[] { "Id", "ColorId", "Type" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 2 },
                    { 3, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "InventoryRawMaterials",
                columns: new[] { "InventoryId", "RawMaterialId", "Quantity" },
                values: new object[] { 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "InventoryRawMaterials",
                columns: new[] { "InventoryId", "RawMaterialId", "Quantity" },
                values: new object[] { 1, 2, 0 });

            migrationBuilder.InsertData(
                table: "InventoryRawMaterials",
                columns: new[] { "InventoryId", "RawMaterialId", "Quantity" },
                values: new object[] { 1, 3, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "InventoryRawMaterials",
                keyColumns: new[] { "InventoryId", "RawMaterialId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "RawMaterials",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RawMaterials",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RawMaterials",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "271e7849-bae5-4e19-8231-93e7ef3c77d1", "AQAAAAEAACcQAAAAENKhoOpon5nndcYb06TpQGcc9Rv8ZEDkcplu0ceUn5+LmI6EZ6m4v3JlyGiG2yhVEQ==" });
        }
    }
}
