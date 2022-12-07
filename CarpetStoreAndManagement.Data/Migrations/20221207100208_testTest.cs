using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class testTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8e68b8b-a8f2-4550-8ba2-8987b57eab2b", "AQAAAAEAACcQAAAAEJsqEslJ9KLK1Y4Leh2rcrowfmVdwCQGUmN3/W+k1Lx4l5m817sOvmAMyKHOC4N/qg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "004571f1-9ed2-4db4-86ff-122c19943354", "AQAAAAEAACcQAAAAEM9L/NoIMC977V69+Fdv7qfIxh8JvXR+gzNBtoaeo1WBf1Dk0nD5Ai/VWrG/ConPlQ==" });
        }
    }
}
