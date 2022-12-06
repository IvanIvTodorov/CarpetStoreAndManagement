using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class productColorConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb8515a2-8a02-4456-b2a7-310c894881fb", "AQAAAAEAACcQAAAAELyQmgCamvkg2xKiPsm7RUsfMUxnu/Q11pSJ7RRuMuinzW87N3dVwb+mz3yVuMEhsA==" });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "ColorId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 2 },
                    { 6, 3 },
                    { 7, 4 },
                    { 2, 5 },
                    { 8, 5 },
                    { 2, 6 },
                    { 7, 6 },
                    { 6, 7 },
                    { 9, 8 },
                    { 2, 9 },
                    { 3, 9 },
                    { 10, 10 },
                    { 6, 11 },
                    { 7, 11 },
                    { 4, 12 },
                    { 6, 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 7, 11 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorId", "ProductId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e381ca1b-f4e5-425e-a94f-6602197d0b4a", "AQAAAAEAACcQAAAAEN5KTKJSJ2wCFxlHVqOuMmh54dt1nf7iTlWaCD4J2OOen90jDlieaOhOoZkUwRnVVg==" });
        }
    }
}
