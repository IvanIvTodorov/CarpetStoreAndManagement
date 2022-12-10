using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.Services.Services;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Tests
{
    public class ProductServiceTests
    {
        private IColorService colorService;

        [Fact]
        public async void TestAddProductAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var model = new AddProductViewModel()
            {
                ImgUrl = "asf",
                Name = "Test",
                Price = 1M,
                Type = "test",
                PrimaryColor = "test",
                SecondaryColor = "test"               
            };

            var success = service.AddProductAsync(model).IsCompletedSuccessfully;

            var expected = await dbContext.Products.ToListAsync();

            Assert.True(expected.Any(x => x.Name == model.Name));
        }

        [Fact]

        public async void TestAddProductToCartAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var user = new User
            {
                Id = "1325125",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "123"
            };

            var product = new Product()
            {
                Id = 215123,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var product2 = new Product()
            {
                Id = 21781123,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var userProd = new UserProduct()
            {
                ProductId = product.Id,
                UserId = user.Id,
                Quantity = 1,
            };

            dbContext.Users.Add(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.Products.AddAsync(product2);
            await dbContext.UserProducts.AddAsync(userProd);
            await dbContext.SaveChangesAsync();

            await service.AddProductToCartAsync(product.Id, user.Id);
            await service.AddProductToCartAsync(product2.Id, user.Id);
            

            var expected = await dbContext.UserProducts.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            var expected2 = await dbContext.UserProducts.Where(x => x.ProductId == product2.Id).FirstOrDefaultAsync();

            Assert.True(expected.Quantity == 2);
            Assert.True(expected2.Quantity == 1);
        }

        [Fact]
        public async void TestDecreaseProductQtyInCartAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var user = new User
            {
                Id = "1234142141244",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "123"
            };

            var product = new Product()
            {
                Id = 217831123,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var userProd = new UserProduct()
            {
                ProductId = product.Id,
                UserId = user.Id,
                Quantity = 2,
            };

            dbContext.Users.Add(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.UserProducts.AddAsync(userProd);
            await dbContext.SaveChangesAsync();

            await service.DecreaseProductQtyInCartAsync(product.Id);

            var expected = await dbContext.UserProducts.Where(x => x.ProductId == product.Id).FirstOrDefaultAsync();

            Assert.True(expected.Quantity == 1);
        }

        [Fact]
        public async void TestGetAllProductsAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 2797,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var expected = await service.GetAllProductsAsync();

            Assert.True(expected.Any(x => x.Id == product.Id));
        }

        [Fact]
        public async void TestGetAllProductsInCartAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var user = new User
            {
                Id = "141244",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "123"
            };

            var product = new Product()
            {
                Id = 2173,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var userProd = new UserProduct()
            {
                ProductId = product.Id,
                UserId = user.Id,
                Quantity = 2,
            };

            dbContext.Users.Add(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.UserProducts.AddAsync(userProd);
            await dbContext.SaveChangesAsync();

            var expected = await service.GetAllProductsInCartAsync(user.Id);

            Assert.True(expected.Any(x => x.Id == product.Id));
        }

        [Fact]
        public async void TestGetProductColors()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 9999,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var color = new Color()
            {
                Id = 979797,
                Name = "test"
            };

            var prodColor = new ProductColor()
            {
                ProductId = product.Id,
                ColorId = color.Id
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.Colors.AddAsync(color);
            await dbContext.ProductColors.AddAsync(prodColor);
            await dbContext.SaveChangesAsync();

            var expected = await service.GetProductColors(product.Id);

            Assert.True(expected.Contains(color.Name));
        }

        [Fact]
        public async void TetsGetProductsAsync()
        {

            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 5454,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var expected = await service.GetProductsAsync();

            Assert.True(expected.Any(x => x.Id == product.Id));
        }

        [Fact]
        public async void TestIncreaseProductQtyInCartAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var user = new User
            {
                Id = "1234141244",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "123"
            };

            var product = new Product()
            {
                Id = 2123,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var userProd = new UserProduct()
            {
                ProductId = product.Id,
                UserId = user.Id,
                Quantity = 2,
            };

            dbContext.Users.Add(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.UserProducts.AddAsync(userProd);
            await dbContext.SaveChangesAsync();

            await service.IncreaseProductQtyInCartAsync(product.Id);

            var expected = await dbContext.UserProducts.Where(x => x.ProductId == product.Id).FirstOrDefaultAsync();

            Assert.True(expected.Quantity == 3);
        }

        [Fact]
        public async void TestProduceProduct()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 1241125,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var product2 = new Product()
            {
                Id = 191191,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var inventory = new Inventory()
            {
                Id = 1241125,
                Name = "TestInvenotry3"
            };

            var inventoryProd = new InventoryProduct()
            {
                InventoryId = inventory.Id,
                ProductId = product.Id,
                Quantity = 1,
            };


            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.Products.AddAsync(product);
            await dbContext.Products.AddAsync(product2);
            await dbContext.InventoryProducts.AddAsync(inventoryProd);

            await dbContext.SaveChangesAsync();

            var model = new ProduceViewModel()
            {
                Quantity = 1,
                InventoryName = inventory.Name
            };

            await service.ProduceProduct(model, product.Id);
            await service.ProduceProduct(model, product2.Id);

            var expected = await dbContext.InventoryProducts.Where(x => x.ProductId == product.Id).FirstOrDefaultAsync();
            var expected2 = await dbContext.InventoryProducts.Where(x => x.ProductId == product2.Id).FirstOrDefaultAsync();

            Assert.True(expected.Quantity == 2);
            Assert.True(expected2.Quantity == 1);
        }

        [Fact]
        public async void TestProductDetailsAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 12878125,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var expected = await service.ProductDetailsAsync(product.Id);

            Assert.True(expected.Id == product.Id);
        }

        [Fact]
        public async void TestRemoveFromCartAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var user = new User
            {
                Id = "15151",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "123"
            };

            var product = new Product()
            {
                Id = 15151515,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var userProd = new UserProduct()
            {
                ProductId = product.Id,
                UserId = user.Id,
                Quantity = 1,
            };

            dbContext.Users.Add(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.UserProducts.AddAsync(userProd);
            await dbContext.SaveChangesAsync();

            await service.RemoveFromCartAsync(product.Id, user.Id);

            var expected = await dbContext.UserProducts.Where(x => x.ProductId == product.Id).FirstOrDefaultAsync();

            Assert.True(expected == null);
        }

        [Fact]
        public async void TestRemoveProductAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 94984,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            await service.RemoveProductAsync(product.Id);

            var expected = await dbContext.Products.Where(x => x.Id == product.Id).FirstOrDefaultAsync();

            Assert.True(expected.IsDeleted);
        }

        [Fact]
        public async void TestGetCurrentUserProduct()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var user = new User
            {
                Id = "4684",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "123"
            };

            var product = new Product()
            {
                Id = 98754,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var userProd = new UserProduct()
            {
                ProductId = product.Id,
                UserId = user.Id,
                Quantity = 1,
            };

            dbContext.Users.Add(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.UserProducts.AddAsync(userProd);
            await dbContext.SaveChangesAsync();

            var expected = await service.GetCurrentUserProduct(product.Id);

            Assert.Equal(expected, userProd);
        }

        [Fact]
        public async void TestGetProductsFromOrderAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var order = new Order()
            {
                Id = 42421,
                TotalPrice = 20
            };

            var product = new Product()
            {
                Id = 8882482,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var prodOrder = new ProductOrder()
            {
                ProductId = product.Id,
                OrderId = order.Id
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.Orders.AddAsync(order);
            await dbContext.ProductOrders.AddAsync(prodOrder);
            await dbContext.SaveChangesAsync();


            var expected = await service.GetProductsFromOrderAsync(order.Id);

            Assert.Equal(expected.FirstOrDefault(), product);
        }

        [Fact]
        public async void TestEditProductAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 1234142,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var expected = await service.EditProductAsync(product.Id);

            Assert.Equal(product.Id, expected.Id);
        }

        [Fact]
        public async void TestEditProductAsyncAfterSubmit()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 124421412,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var color = new Color()
            {
                Id = 12499741,
                Name = "test"
            };

            var pordColor = new ProductColor()
            {
                ProductId = product.Id,
                ColorId = color.Id
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.Colors.AddAsync(color);
            await dbContext.ProductColors.AddAsync(pordColor);

            await dbContext.SaveChangesAsync();

            var model = new EditProductViewModel()
            {
                Id = 124421412,
                ImgUrl = "changed",
                Name = "Test",
                Price = 1M,
                Type = "test",
                PrimaryColor = "Test"
            };

            await service.EditProductAsync(model);

            var expected = await dbContext.Products.Where(x => x.Id == product.Id).FirstOrDefaultAsync();

            Assert.True(expected.ImgUrl == model.ImgUrl);
        }

        [Fact]
        public async void TestEditProductColorAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 12901412,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var primary = new Color()
            {
                Id = 1241241,
                Name = "test"
            };

            var secondary = new Color()
            {
                Id = 545417,
                Name = "teest"
            };

            var pordColor = new ProductColor()
            {
                ProductId = product.Id,
                ColorId = primary.Id
            };

            var pordColor2 = new ProductColor()
            {
                ProductId = product.Id,
                ColorId = secondary.Id
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.Colors.AddAsync(primary);
            await dbContext.Colors.AddAsync(secondary);
            await dbContext.ProductColors.AddAsync(pordColor);
            await dbContext.ProductColors.AddAsync(pordColor2);

            await dbContext.SaveChangesAsync();

            var changePrimary = "Test1";
            var changeSecondary = "Test2";

            await service.EditProductColorAsync(product.Id, changePrimary, changeSecondary);
            var success = service.EditProductColorAsync(product.Id, changePrimary, changeSecondary).IsCompletedSuccessfully;

            var primaryExpected = await dbContext.Colors.Where(x => x.Id == primary.Id).FirstOrDefaultAsync();
            var secondaryExpected = await dbContext.Colors.Where(x => x.Id == secondary.Id).FirstOrDefaultAsync();

            Assert.True(primaryExpected.Name == changePrimary);
            Assert.True(secondaryExpected.Name == changeSecondary);
            Assert.True(success);

            await service.EditProductColorAsync(product.Id, changePrimary, "");
            success = service.EditProductColorAsync(product.Id, changePrimary, "").IsCompletedSuccessfully;

            var secondaryExpected2 = await dbContext.Colors.Where(x => x.Id == secondary.Id).FirstOrDefaultAsync();

            Assert.True(secondary.Name == secondaryExpected2.Name);
            Assert.True(success);
        }

        [Fact]
        public async void TestProductIdExist()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 100101,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var success = await service.ProductIdExist(product.Id);

            Assert.True(success);
        }

        [Fact]
        public async void TestGetProductsByTypeAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 10015458,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var expected = await service.GetProductsByTypeAsync(product.Type);

            Assert.True(expected.Any(x => x.Type == product.Type));
        }

        [Fact]
        public async void TestCheckIfTypeExistAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 1104855,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var success = await service.CheckIfTypeExistAsync(product.Type);

            Assert.True(success);
        }

        [Fact]
        public async void TestGetAllProductTypesAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 214142,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var expected = await service.GetAllProductTypesAsync();


            Assert.True(expected.Contains(product.Type));
        }

        [Fact]
        public async void TestPorductsByTypeAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ProductService(dbContext, sanitizer, colorService);

            var product = new Product()
            {
                Id = 889923,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var expected = await service.PorductsByTypeAsync(product.Type);

            Assert.True(expected.Any(x => x.Id == product.Id));
        }

    }
}
