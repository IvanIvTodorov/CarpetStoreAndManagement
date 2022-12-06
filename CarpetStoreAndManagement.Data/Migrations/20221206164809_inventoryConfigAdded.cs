using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class inventoryConfigAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7681d250-df8c-4d3f-b7b6-3e8604c11cc5", "AQAAAAEAACcQAAAAEPmCoHBfZ3JgS91KsTblpU2ptm9Q+Ipznw+ZJkPzIwV3WaJ1z8mnvBtKD9EK7Mv2Hw==" });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Central" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0af857f0-0765-4d66-a8f1-d0c634fda5ba", "AQAAAAEAACcQAAAAENZAap46fj0DsjshNite6bKKnO8SKTECOhwRuMyHuAnSVLdDXHDErjM7lxvefvmjHA==" });
        }
    }
}
