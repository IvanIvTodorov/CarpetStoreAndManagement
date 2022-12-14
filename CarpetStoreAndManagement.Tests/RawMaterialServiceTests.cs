using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Services.Services;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Tests
{
    public class RawMaterialServiceTests
    {
        [Fact]
        public async void TestAddRawMaterialAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new RawMaterialService(dbContext, sanitizer);

            var type = RawMaterialType.Yarn;

            var color = new Color()
            {
                Id = 1231234213,
                Name = "Test"
            };

            var inventory = new Inventory()
            {
                Id = 12314124,
                Name = "test"
            };

            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.Colors.AddAsync(color);
            await dbContext.SaveChangesAsync();

            var model = new AddRawMaterialViewModel()
            {
                Color = "Test",
                InventoryName = "test",
                Quantity = 1
            };

          
            await service.AddRawMaterialAsync(model, type);

            var expected = await dbContext.RawMaterials.AnyAsync(x => x.Color.Name == model.Color);

            Assert.True(expected);

            var rawMat = new RawMaterial()
            {
                ColorId = color.Id,
                Id = 1244232,
                Type = type
            };

            await dbContext.RawMaterials.AddAsync(rawMat);

            await dbContext.SaveChangesAsync();

            await service.AddRawMaterialAsync(model, type);

            Assert.True(expected);
        }

        [Fact]

        public async void TestAddToInventoryAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new RawMaterialService(dbContext, sanitizer);

            var inventory = new Inventory()
            {
                Id = 12312,
                Name = "test"
            };

            var color = new Color()
            {
                Id = 214141241,
                Name = "test"
            };

            var rawMaterial = new RawMaterial()
            {
                Id = 123412,
                ColorId = color.Id,
                Type = RawMaterialType.Warp,
            };

            var qty = 1;

            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.Colors.AddAsync(color);
            await dbContext.RawMaterials.AddAsync(rawMaterial);
            await dbContext.SaveChangesAsync();

            await service.AddToInventoryAsync(rawMaterial.Id, inventory.Name, qty);

            var expected = await dbContext.InventoryRawMaterials.AnyAsync(x => x.RawMaterial.Id == rawMaterial.Id);

            Assert.True(expected);
        }

        [Fact]

        public async void TestGetRawMatInInventoryBySearch()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new RawMaterialService(dbContext, sanitizer);

            var inventory = new Inventory()
            {
                Id = 123124214,
                Name = "test"
            };

            var color = new Color()
            {
                Id = 21414141,
                Name = "test"
            };

            var rawMaterial = new RawMaterial()
            {
                Id = 123412412,
                ColorId = color.Id,
                Type = RawMaterialType.Warp,
            };

            var qty = 1;

            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.Colors.AddAsync(color);
            await dbContext.RawMaterials.AddAsync(rawMaterial);
            await dbContext.SaveChangesAsync();

            await service.AddToInventoryAsync(rawMaterial.Id, inventory.Name, qty);

            var model = new RawMaterialsInInventoryViewModel()
            {
                InventoryName = inventory.Name,
                Color = color.Name
            };

            var expected = await service.GetRawMatInInventoryBySearchAsync(model);

            Assert.True(expected.Any(x => x.RawMaterialId == rawMaterial.Id));
        }
    }
}
