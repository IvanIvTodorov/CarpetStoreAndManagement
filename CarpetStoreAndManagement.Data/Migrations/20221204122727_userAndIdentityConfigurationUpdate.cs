using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class userAndIdentityConfigurationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdf7752f-91c2-40b5-a284-534f471cf04c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a3dbbbd-9006-4273-8754-e0f17caea2f5", "3978c4ef-e522-40ef-9cae-bcffb7978f70" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a3dbbbd-9006-4273-8754-e0f17caea2f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3978c4ef-e522-40ef-9cae-bcffb7978f70");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2148ea66-d73d-4636-9cc7-22bfaa9796ba", "2148ea66-d73d-4636-9cc7-22bfaa9796ba", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc68c20c-33c1-4737-9e5e-16b8384e8977", "dc68c20c-33c1-4737-9e5e-16b8384e8977", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41d1aea7-5764-4ebb-8a0d-055594610abb", 0, "6432b871-deb8-459b-8078-89788532f0e1", "ivan@abv.bg", true, false, null, "IVAN@ABV.BG", "IVAN", "AQAAAAEAACcQAAAAEGoepjfpMz7Xr49G71qytpn1VRVmdgQh69w9H86b6v9bSXpHOVXikGotxKb2guL/hQ==", "+111111111111", true, "41d1aea7-5764-4ebb-8a0d-055594610abb", false, "Ivan" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dc68c20c-33c1-4737-9e5e-16b8384e8977", "41d1aea7-5764-4ebb-8a0d-055594610abb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2148ea66-d73d-4636-9cc7-22bfaa9796ba");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc68c20c-33c1-4737-9e5e-16b8384e8977", "41d1aea7-5764-4ebb-8a0d-055594610abb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc68c20c-33c1-4737-9e5e-16b8384e8977");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a3dbbbd-9006-4273-8754-e0f17caea2f5", "6a3dbbbd-9006-4273-8754-e0f17caea2f5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bdf7752f-91c2-40b5-a284-534f471cf04c", "bdf7752f-91c2-40b5-a284-534f471cf04c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3978c4ef-e522-40ef-9cae-bcffb7978f70", 0, "15b16252-a108-47a5-a4c9-53a5b228f31a", "ivan@abv.bg", true, false, null, "IVAN@ABV.BG", "IVAN", "AQAAAAEAACcQAAAAEMG5sTZtfzaq2354XVS5jsUR+bQAjqpJxDHO5CAKqH0+GIAuSXUIcF4NDJppocdIbw==", "+111111111111", true, "3978c4ef-e522-40ef-9cae-bcffb7978f70", false, "Ivan" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6a3dbbbd-9006-4273-8754-e0f17caea2f5", "3978c4ef-e522-40ef-9cae-bcffb7978f70" });
        }
    }
}
