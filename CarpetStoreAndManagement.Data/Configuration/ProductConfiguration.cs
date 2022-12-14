using CarpetStoreAndManagement.Data.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpetStoreAndManagement.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(CreateCarpets());
        }

        public List<Product> CreateCarpets()
        {
            var products = new List<Product>();

            var firstProduct = new Product()
            {
                //Brown
                Id = 1,
                ImgUrl = "https://www.e-kilimi.com/uploads/com_article/gallery/062da0dfa1b262854b14a04c0f91e3d4ed2e8086.jpg",
                Name = "Nehir",
                Price = 10.5M,
                IsDeleted = false,
                Type = "Carpet",
            };

            var secondProduct = new Product()
            {
                //gray
                Id = 2,
                ImgUrl = "https://www.e-kilimi.com/uploads/com_article/gallery/0cde9e862fcf46270e1cb5d6c5c61656eb6ce3a3.jpg",
                Name = "Sahar",
                Price = 8.5M,
                IsDeleted = false,
                Type = "Carpet",
            };

            var thirdProduct = new Product()
            {
                //beige
                Id = 3,
                ImgUrl = "https://www.e-kilimi.com/uploads/com_article/gallery/57b812b1fffaea9b8a309adb18594d805f3f81f9.jpg",
                Name = "Bahar",
                Price = 15.5M,
                IsDeleted = false,
                Type = "Carpet",
            };

            var fourthProduct = new Product()
            {
                //green
                Id = 4,
                ImgUrl = "https://domtextilu.s14.cdn-upgates.com/_cache/7/f/7fd25c6864f8df5af92d438c386d6730.jpg",
                Name = "Sofia",
                Price = 10.5M,
                IsDeleted = false,
                Type = "Carpet",
            };

            var fifthProduct = new Product()
            {
                // white and blue
                Id = 5,
                ImgUrl = "https://m.media-amazon.com/images/I/51o3KTsZqUL._AC_SY580_.jpg",
                Name = "Amaya",
                Price = 9.5M,
                IsDeleted = false,
                Type = "Carpet",
            };

            var sixstProduct = new Product()
            {
                // green and white
                Id = 6,
                ImgUrl = "https://m.media-amazon.com/images/I/51KuKwOewHL._AC_.jpg",
                Name = "Amira",
                Price = 10.5M,
                IsDeleted = false,
                Type = "Carpet",
            };

            var firstPath = new Product()
            {
                // beige
                Id = 7,
                ImgUrl = "https://kilimi.com/wp-content/uploads/2021/09/Ednotsvetna-pateka-Bela-Bezhov-1.jpg",
                Name = "Alisa",
                Price = 10.5M,
                IsDeleted = false,
                Type = "Path",
            };

            var secondPath = new Product()
            {
                // dark vision
                Id = 8,
                ImgUrl = "https://kilimi.com/wp-content/uploads/2021/11/Moderna-pateka-Atlas-878-Tamen-Vizon.jpg",
                Name = "Vision",
                Price = 14.5M,
                IsDeleted = false,
                Type = "Path",
            };

            var thirdPath = new Product()
            {
                // Black and White
                Id = 9,
                ImgUrl = "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Siv.jpg",
                Name = "Checkmate",
                Price = 10.5M,
                IsDeleted = false,
                Type = "Path",
            };

            var forthPath = new Product()
            {
                // Dark Brown
                Id = 10,
                ImgUrl = "https://kilimi.com/wp-content/uploads/2021/11/Moderna-pateka-Atlas-855-Tamno-Kafyav.jpg",
                Name = "Siera",
                Price = 17.5M,
                IsDeleted = false,
                Type = "Path",
            };

            var fifthPath = new Product()
            {
                // green and beige
                Id = 11,
                ImgUrl = "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Bezhov-Zelen.jpg",
                Name = "Modern",
                Price = 16.5M,
                IsDeleted = false,
                Type = "Path",
            };

            var sixstPath = new Product()
            {
                // beige and orange
                Id = 12,
                ImgUrl = "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Bezhov-Oranzhev.jpg",
                Name = "Modern",
                Price = 18.5M,
                IsDeleted = false,
                Type = "Path",
            };

            products.Add(firstProduct);
            products.Add(secondProduct);
            products.Add(thirdProduct);
            products.Add(fourthProduct);
            products.Add(fifthProduct);
            products.Add(sixstProduct);
            products.Add(firstPath);
            products.Add(secondPath);
            products.Add(thirdPath);
            products.Add(forthPath);
            products.Add(fifthPath);
            products.Add(sixstPath);
            return products;
        }
    }
}
