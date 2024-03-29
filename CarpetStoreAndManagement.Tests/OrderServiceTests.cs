﻿using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.Services.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarpetStoreAndManagement.Tests
{
    public class OrderServiceTests
    {
        private IProductService productService;
        private IInventoryService inventoryService;

        [Fact]
        public async void TestCheckIfOrderExist()
        {

            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new OrderService(dbContext, productService, inventoryService);

            var order = new Order()
            {
                Id = 1,
                TotalPrice = 20
            };

            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();

            var expected = await service.CheckIfOrderExistAsync(order.Id);

            Assert.True(expected);
        }

        [Fact]
        public async void TestCompleteOrderAsync()
        {
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new OrderService(dbContext, productService, inventoryService);

            var order = new Order()
            {
                Id = 2,
                TotalPrice = 20
            };

            var user = new User
            {
                Id = "123",
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
                Id = 2141245,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };
            var inventory = new Inventory()
            {
                Id = 124124,
                Name = "test"
            };

            var orderProduct = new ProductOrder()
            {
                ProductId = product.Id,
                OrderId = order.Id,
                Quantity = 1
            };


            var inventProd = new InventoryProduct()
            {
                ProductId = product.Id,
                InventoryId = inventory.Id,
                Quantity = 2
            };

            var userOrder = new UserOrder()
            {
                UserId = user.Id,
                OrderId = order.Id
            };

            await dbContext.Products.AddAsync(product);
            dbContext.Users.Add(user);
            await dbContext.Orders.AddAsync(order);
            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.ProductOrders.AddAsync(orderProduct);
            await dbContext.InventoryProducts.AddAsync(inventProd);
            await dbContext.UserOrders.AddAsync(userOrder);

            await dbContext.SaveChangesAsync();

            await service.CompleteOrderAsync(order.Id);

            var expected = await dbContext.UserOrders
                .Where(x => x.OrderId == order.Id)
                .FirstOrDefaultAsync();

            Assert.True(expected.IsCompleted);
        }

        [Fact]

        public async void TestGetAllOrdersAsync()
        {
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new OrderService(dbContext, productService, inventoryService);

            var order = new Order()
            {
                Id = 2412,
                TotalPrice = 20
            };

            var user = new User
            {
                Id = "1234",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "123"
            };

            var userOrder = new UserOrder()
            {
                UserId = user.Id,
                OrderId = order.Id
            };

            var product = new Product()
            {
                Id = 333232,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var primary = new Color()
            {
                Id = 33232,
                Name = "test"
            };

            var secondary = new Color()
            {
                Id = 123414,
                Name = "test"
            };

            var prodColor = new ProductColor()
            {
                ProductId = product.Id,
                ColorId = primary.Id,
                ColorType = ProductColorType.PrimaryColor
            };

            var prodColor2 = new ProductColor()
            {
                ProductId = product.Id,
                ColorId = secondary.Id,
                ColorType = ProductColorType.SecondaryColor
            };

            var prodOrder = new ProductOrder()
            {
                ProductId = product.Id,
                OrderId = order.Id
            };

            await dbContext.Orders.AddAsync(order);
            await dbContext.Products.AddAsync(product);
            await dbContext.Colors.AddAsync(primary);
            await dbContext.Colors.AddAsync(secondary);
            dbContext.Users.Add(user);
            await dbContext.UserOrders.AddAsync(userOrder);
            await dbContext.ProductColors.AddAsync(prodColor2);
            await dbContext.ProductColors.AddAsync(prodColor);
            await dbContext.ProductOrders.AddAsync(prodOrder);

            await dbContext.SaveChangesAsync();

            var expected = await service.GetAllOrdersAsync();

            Assert.True(expected.Where(x => x.OrderId == order.Id).FirstOrDefault().OrderId == order.Id);
        }

        [Fact]

        public async void TestGetMyOrdersAsync()
        {
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new OrderService(dbContext, productService, inventoryService);

            var order = new Order()
            {
                Id = 24123,
                TotalPrice = 20
            };

            var user = new User
            {
                Id = "1234214",
                Email = "ivan@abv.bg",
                NormalizedEmail = "IVAN@ABV.BG",
                UserName = "Ivan",
                NormalizedUserName = "IVAN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "123"
            };

            var userOrder = new UserOrder()
            {
                UserId = user.Id,
                OrderId = order.Id
            };
            var product = new Product()
            {
                Id = 11155243,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var primary = new Color()
            {
                Id = 1114423,
                Name = "test"
            };

            var secondary = new Color()
            {
                Id = 1115312,
                Name = "test"
            };

            var prodColor = new ProductColor()
            {
                ProductId = product.Id,
                ColorId = primary.Id,
                ColorType = ProductColorType.PrimaryColor
            };

            var prodColor2 = new ProductColor()
            {
                ProductId = product.Id,
                ColorId = secondary.Id,
                ColorType = ProductColorType.SecondaryColor
            };

            var prodOrder = new ProductOrder()
            {
                ProductId = product.Id,
                OrderId = order.Id
            };

            await dbContext.Orders.AddAsync(order);
            await dbContext.Products.AddAsync(product);
            await dbContext.Colors.AddAsync(primary);
            await dbContext.Colors.AddAsync(secondary);
            dbContext.Users.Add(user);
            await dbContext.UserOrders.AddAsync(userOrder);
            await dbContext.ProductColors.AddAsync(prodColor2);
            await dbContext.ProductColors.AddAsync(prodColor);
            await dbContext.ProductOrders.AddAsync(prodOrder);

            await dbContext.SaveChangesAsync();

            var expected = await service.GetMyOrdersAsync(user.Id);

            Assert.True(expected.Where(x => x.OrderId == order.Id).FirstOrDefault().OrderId == order.Id);
        }

        [Fact]
        public async void TestMakeOrderAsync()
        {
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new OrderService(dbContext, productService, inventoryService);


            var user = new User
            {
                Id = "12342141244",
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
                Id = 111231123,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var color = new Color()
            {
                Id = 123123123,
                Name = "Test",
            };

            var prodColor = new ProductColor()
            {
                ColorId = color.Id,
                ProductId = product.Id,
            };

            var userProd = new UserProduct()
            {
                ProductId = product.Id,
                UserId = user.Id
            };

            dbContext.Users.Add(user);
            await dbContext.Products.AddAsync(product);
            await dbContext.Colors.AddAsync(color);
            await dbContext.ProductColors.AddAsync(prodColor);
            await dbContext.UserProducts.AddAsync(userProd);
            await dbContext.SaveChangesAsync();

            await service.MakeOrderAsync(user.Id);

            var expected = await dbContext.UserOrders.AnyAsync(x => x.UserId == user.Id);

            Assert.True(expected);
        }

        [Fact]
        public async void TestSetProduceFromOrderViewModelAsync()
        {
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var prodService = new Mock<IProductService>();

            var product = new Product()
            {
                Id = 11421123,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var list = new List<Product> { product };
            prodService.Setup(x => x.GetProductsFromOrderAsync(5)).Returns(Task.FromResult<IEnumerable<Product>>(list));

            var repo = prodService.Object;

            var invService = new Mock<IInventoryService>();

            var invent = new Inventory()
            {
                Id = 214124,
                Name = "test"

            };

            var invList = new List<Inventory> { invent };
            invService.Setup(x => x.GetInventoriesAsync()).Returns(Task.FromResult<IEnumerable<Inventory>>(invList));
            var invRepo = invService.Object;

            var service = new OrderService(dbContext, repo, invRepo);

            var expected = await service.SetProduceFromOrderViewModelAsync(5);

            Assert.Equal(expected.Products.FirstOrDefault(), product);
        }

    }
}
