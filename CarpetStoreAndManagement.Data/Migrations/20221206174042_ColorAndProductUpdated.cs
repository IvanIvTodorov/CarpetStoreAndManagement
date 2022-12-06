using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    public partial class ColorAndProductUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e381ca1b-f4e5-425e-a94f-6602197d0b4a", "AQAAAAEAACcQAAAAEN5KTKJSJ2wCFxlHVqOuMmh54dt1nf7iTlWaCD4J2OOen90jDlieaOhOoZkUwRnVVg==" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Brown" },
                    { 2, "White" },
                    { 3, "Black" },
                    { 4, "Orange" },
                    { 5, "Gray" },
                    { 6, "Beige" },
                    { 7, "Green" },
                    { 8, "Blue" },
                    { 9, "Dark vision" },
                    { 10, "Dark brown" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ImgUrl", "IsDeleted", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 1, "https://www.e-kilimi.com/uploads/com_article/gallery/062da0dfa1b262854b14a04c0f91e3d4ed2e8086.jpg", false, "Nehir", 10.5m, "Carpet" },
                    { 2, "https://www.e-kilimi.com/uploads/com_article/gallery/0cde9e862fcf46270e1cb5d6c5c61656eb6ce3a3.jpg", false, "Sahar", 8.5m, "Carpet" },
                    { 3, "https://www.e-kilimi.com/uploads/com_article/gallery/57b812b1fffaea9b8a309adb18594d805f3f81f9.jpg", false, "Bahar", 15.5m, "Carpet" },
                    { 4, "https://domtextilu.s14.cdn-upgates.com/_cache/7/f/7fd25c6864f8df5af92d438c386d6730.jpg", false, "Sofia", 10.5m, "Carpet" },
                    { 5, "https://m.media-amazon.com/images/I/51o3KTsZqUL._AC_SY580_.jpg", false, "Amaya", 9.5m, "Carpet" },
                    { 6, "https://m.media-amazon.com/images/I/51KuKwOewHL._AC_.jpg", false, "Amira", 10.5m, "Carpet" },
                    { 7, "https://kilimi.com/wp-content/uploads/2021/09/Ednotsvetna-pateka-Bela-Bezhov-1.jpg", false, "Alisa", 10.5m, "Carpet" },
                    { 8, "https://kilimi.com/wp-content/uploads/2021/11/Moderna-pateka-Atlas-878-Tamen-Vizon.jpg", false, "Vision", 14.5m, "Carpet" },
                    { 9, "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Siv.jpg", false, "Checkmate", 10.5m, "Carpet" },
                    { 10, "https://kilimi.com/wp-content/uploads/2021/11/Moderna-pateka-Atlas-855-Tamno-Kafyav.jpg", false, "Siera", 17.5m, "Carpet" },
                    { 11, "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Bezhov-Zelen.jpg", false, "Modern", 16.5m, "Carpet" },
                    { 12, "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Bezhov-Oranzhev.jpg", false, "Modern", 18.5m, "Carpet" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d1aea7-5764-4ebb-8a0d-055594610abb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c3a332ad-1456-4579-96be-3d46d0cc64e8", "AQAAAAEAACcQAAAAEMtruusUF0g3qpIirVVrtCi+7d5mh5Qs4adjCqbSdcyNSZ+Ebaj0DhjC6dV1IsVvQA==" });
        }
    }
}
