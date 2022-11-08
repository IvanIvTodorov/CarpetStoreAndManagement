using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryRawMaterials",
                table: "InventoryRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_InventoryRawMaterials_InventoryId",
                table: "InventoryRawMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryRawMaterials",
                table: "InventoryRawMaterials",
                columns: new[] { "InventoryId", "RawMaterialId" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryRawMaterials_RawMaterialId",
                table: "InventoryRawMaterials",
                column: "RawMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryRawMaterials",
                table: "InventoryRawMaterials");

            migrationBuilder.DropIndex(
                name: "IX_InventoryRawMaterials_RawMaterialId",
                table: "InventoryRawMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryRawMaterials",
                table: "InventoryRawMaterials",
                columns: new[] { "RawMaterialId", "InventoryId" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryRawMaterials_InventoryId",
                table: "InventoryRawMaterials",
                column: "InventoryId");
        }
    }
}
