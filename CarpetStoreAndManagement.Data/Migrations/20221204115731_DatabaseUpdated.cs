using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class DatabaseUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
