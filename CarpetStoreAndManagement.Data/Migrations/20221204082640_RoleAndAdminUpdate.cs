using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class RoleAndAdminUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "341743f0-asd2–42de-afbf-59kmkkmk72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "Admins", "ADMINS" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Budget", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, 0m, "4cf65ba8-dcc7-4da5-a2e7-504d9766e2bb", "xxxx@example.com", true, false, null, "XXXX@EXAMPLE.COM", "VANKO", "AQAAAAEAACcQAAAAED7avyldjuaj+jccOpdzsujhuRIVC2T3pR0YW3wCbZ5TG03VVV1Ozurt0VWZ9yfWyw==", "+111111111111", true, "1017f2b3-cda3-4734-bff0-87eaefc2394b", false, "Vanko" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });
        }
    }
}
