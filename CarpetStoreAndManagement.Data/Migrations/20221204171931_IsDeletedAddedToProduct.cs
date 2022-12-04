using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class IsDeletedAddedToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9919b1f-40dc-4264-8a8e-8d572e11717f", "AQAAAAEAACcQAAAAEBNfnvuXJtAldJOFW26C0uXLg76aj8J72AyuGKhoLKxOqAVuujMkQcBH1aiprMf5tA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6432b871-deb8-459b-8078-89788532f0e1", "AQAAAAEAACcQAAAAEGoepjfpMz7Xr49G71qytpn1VRVmdgQh69w9H86b6v9bSXpHOVXikGotxKb2guL/hQ==" });
        }
    }
}
