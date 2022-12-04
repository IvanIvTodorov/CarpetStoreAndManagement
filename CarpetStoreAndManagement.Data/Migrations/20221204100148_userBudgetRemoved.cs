using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class userBudgetRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d91c070c-71a4-49c6-9940-6404439e26e3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "913c37cb-9541-4cc8-9d10-aa9e8ffad4c1", "47270c24-7b9a-4d67-bdf9-c941a035e2d1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "913c37cb-9541-4cc8-9d10-aa9e8ffad4c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "47270c24-7b9a-4d67-bdf9-c941a035e2d1");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e8fe842-ba88-4dd3-9266-ef7fe25b11ed", "0e8fe842-ba88-4dd3-9266-ef7fe25b11ed", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "856ad83d-ed75-4268-86ce-aa9f72463d7d", "856ad83d-ed75-4268-86ce-aa9f72463d7d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eae8ea29-0617-47d9-bb28-cf5419d4016e", 0, "96cf3a3b-f53a-495b-b604-591932cc96e8", "ivan@abv.bg", true, false, null, "IVAN@ABV.BG", "IVAN", "AQAAAAEAACcQAAAAEKx+YcjdQSN94rJfTCrH88tytcC8Z/DgaWz0eVXKKujS41/JU5lKTaB822IfT5isfw==", "+111111111111", true, "eae8ea29-0617-47d9-bb28-cf5419d4016e", false, "Ivan" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e8fe842-ba88-4dd3-9266-ef7fe25b11ed", "eae8ea29-0617-47d9-bb28-cf5419d4016e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "856ad83d-ed75-4268-86ce-aa9f72463d7d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e8fe842-ba88-4dd3-9266-ef7fe25b11ed", "eae8ea29-0617-47d9-bb28-cf5419d4016e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e8fe842-ba88-4dd3-9266-ef7fe25b11ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eae8ea29-0617-47d9-bb28-cf5419d4016e");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "913c37cb-9541-4cc8-9d10-aa9e8ffad4c1", "913c37cb-9541-4cc8-9d10-aa9e8ffad4c1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d91c070c-71a4-49c6-9940-6404439e26e3", "d91c070c-71a4-49c6-9940-6404439e26e3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Budget", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "47270c24-7b9a-4d67-bdf9-c941a035e2d1", 0, 0m, "1903f3ab-e2f6-4ba9-af07-fb1081a30bb5", "ivan@abv.bg", true, false, null, "IVAN@ABV.BG", "IVAN", "AQAAAAEAACcQAAAAEBE5U9y/TQ6sRiea4QBklnFunYrKWZz4lWgT5JRuS4prZokSi/i/i78Aa+2L2Fo4lg==", "+111111111111", true, "47270c24-7b9a-4d67-bdf9-c941a035e2d1", false, "Ivan" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "913c37cb-9541-4cc8-9d10-aa9e8ffad4c1", "47270c24-7b9a-4d67-bdf9-c941a035e2d1" });
        }
    }
}
