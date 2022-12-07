using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class tablesUpdatedFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19ff04c6-b5d8-4111-b9ff-0ce7f6563b53", "AQAAAAEAACcQAAAAEN79UI7U/CZHua2Fhxkxr+PPk74wH2mtERSlObhZZSRyco40DdnRfobElAJu1uajOw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Inventories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a8e68b8b-a8f2-4550-8ba2-8987b57eab2b", "AQAAAAEAACcQAAAAEJsqEslJ9KLK1Y4Leh2rcrowfmVdwCQGUmN3/W+k1Lx4l5m817sOvmAMyKHOC4N/qg==" });
        }
    }
}
