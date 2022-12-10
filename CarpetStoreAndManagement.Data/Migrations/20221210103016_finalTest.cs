using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class finalTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2436f4e6-64a8-424e-9374-87c2b05f63d3", "AQAAAAEAACcQAAAAEE4ND8+J+pXDoyTVEDqOubIzq/r5xhWT2ur2ai9rpVeBIJbo+UoAtLMqSS/6UjHdyw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19ff04c6-b5d8-4111-b9ff-0ce7f6563b53", "AQAAAAEAACcQAAAAEN79UI7U/CZHua2Fhxkxr+PPk74wH2mtERSlObhZZSRyco40DdnRfobElAJu1uajOw==" });
        }
    }
}
