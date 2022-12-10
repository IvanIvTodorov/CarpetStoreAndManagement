using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class prodColorTypeUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorType",
                table: "ProductColors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e135af4-dd89-4d3e-8b2c-8fec18cafc08", "AQAAAAEAACcQAAAAEOIQTCV/7glPYAGthK6NzSgdj4pd9dJrhQnYzJP78gf3ynnXK6Sy1jB3IEhNzGSq3g==" });

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 8, 5 },
                column: "ColorType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 6 },
                column: "ColorType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 9 },
                column: "ColorType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 11 },
                column: "ColorType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 4, 12 },
                column: "ColorType",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorType",
                table: "ProductColors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19ff04c6-b5d8-4111-b9ff-0ce7f6563b53", "AQAAAAEAACcQAAAAEN79UI7U/CZHua2Fhxkxr+PPk74wH2mtERSlObhZZSRyco40DdnRfobElAJu1uajOw==" });
        }
    }
}
