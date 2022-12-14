using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.Services.Services;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarpetStoreAndManagement.Tests
{
    public class InventoryServiceTests
    {
        private IColorService colorService;
        private IProductService productService;
        [Fact]
        public async void TestGetInventoriesAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new InventoryService(dbContext, sanitizer, colorService, productService);

            var inventory = new Inventory()
            {
                Name = "TestInventory"
            };

            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.SaveChangesAsync();

            var result = await service.GetInventoriesAsync();


            Assert.True(result.Any(x => x.Name == inventory.Name));
        }
        [Fact]
        public async void TestAddInventoryAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new InventoryService(dbContext, sanitizer, colorService, productService);

            var inventoryName = "TestInventory2";

            await service.AddInventoryAsync(inventoryName);

            var expected = await dbContext.Inventories.ToListAsync();


            Assert.True(expected.Any(x => x.Name == inventoryName));
        }

        [Fact]
        public async void GetAllItemsAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new InventoryService(dbContext, sanitizer, colorService, productService);

            var product = new Product()
            {
                Id = 111,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };


            var color = new Color()
            {
                Id = 111,
                Name = "TestColor",
            };

            var rawMaterial = new RawMaterial()
            {
                Id = 111,
                Type = RawMaterialType.Yarn,
                ColorId = color.Id,
            };

            var inventory = new Inventory()
            {
                Id = 111,
                Name = "TestInvenotry3"
            };

            var inventoryProd = new InventoryProduct()
            {
                InventoryId = inventory.Id,
                ProductId = product.Id,
                Quantity = 1,
            };

            var inventoryRawMat = new InventoryRawMaterial()
            {
                InventoryId = inventory.Id,
                RawMaterialId = rawMaterial.Id,
                Quantity = 1,
            };


            await dbContext.Colors.AddAsync(color);
            await dbContext.RawMaterials.AddAsync(rawMaterial);
            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.Products.AddAsync(product);
            await dbContext.InventoryProducts.AddAsync(inventoryProd);
            await dbContext.InventoryRawMaterials.AddAsync(inventoryRawMat);

            await dbContext.SaveChangesAsync();


            var expectedModel = await service.GetAllItemsAsync();

            Assert.True(expectedModel.RawMaterials.Any(x => x.RawMaterialId == rawMaterial.Id));
            Assert.True(expectedModel.Products.Any(x => x.ProductId == product.Id));
        }

        [Fact]
        public async void TetsDecreaseUsedRawMaterialsInInventory()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new InventoryService(dbContext, sanitizer, colorService, productService);

            var color = new Color()
            {
                Id = 555,
                Name = "Test"
            };

            var listColors = new List<string>() { color.Name };
            var qty = 1;
            var inventory = new Inventory()
            {
                Name = "Test",
                Id = 555
            };

            var rawMat = new RawMaterial()
            {
                ColorId = color.Id,
                Type = RawMaterialType.Warp,
                Id = 897
            };

            var invenotryRawMat = new InventoryRawMaterial()
            {
                RawMaterialId = rawMat.Id,
                InventoryId = inventory.Id,
                Quantity = 2
            };

            await dbContext.Colors.AddAsync(color);
            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.RawMaterials.AddAsync(rawMat);
            await dbContext.InventoryRawMaterials.AddAsync(invenotryRawMat);

            await dbContext.SaveChangesAsync();

            await service.DecreaseUsedRawMaterialsInInventoryAsync(listColors, qty, inventory.Name);

            var expected = await dbContext.InventoryRawMaterials.Where(x => x.RawMaterialId == rawMat.Id).FirstOrDefaultAsync();

            Assert.Equal(expected.Quantity, qty);
        }

        [Fact]

        public async void TestCheckRawMaterialsForProduce()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new InventoryService(dbContext, sanitizer, colorService, productService);

            var color = new Color()
            {
                Id = 888,
                Name = "Test"
            };

            var listColors = new List<string>() { color.Name };
            var qty = 1;
            var inventory = new Inventory()
            {
                Name = "Test",
                Id = 124
            };

            var rawMat = new RawMaterial()
            {
                ColorId = color.Id,
                Type = RawMaterialType.Warp,
                Id = 555
            };

            var rawMat2 = new RawMaterial()
            {
                ColorId = color.Id,
                Type = RawMaterialType.Weft,
                Id = 888
            };

            var rawMat3 = new RawMaterial()
            {
                ColorId = color.Id,
                Type = RawMaterialType.Yarn,
                Id = 999
            };

            var invenotryRawMat = new InventoryRawMaterial()
            {
                RawMaterialId = rawMat.Id,
                InventoryId = inventory.Id,
                Quantity = 2
            };

            var invenotryRawMat2 = new InventoryRawMaterial()
            {
                RawMaterialId = rawMat2.Id,
                InventoryId = inventory.Id,
                Quantity = 2
            };

            var invenotryRawMat3 = new InventoryRawMaterial()
            {
                RawMaterialId = rawMat3.Id,
                InventoryId = inventory.Id,
                Quantity = 2
            };

            var expectedFalse = await service.CheckRawMaterialsForProduceAsync(listColors, qty, inventory.Name);

            await dbContext.Colors.AddAsync(color);
            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.RawMaterials.AddAsync(rawMat);
            await dbContext.RawMaterials.AddAsync(rawMat2);
            await dbContext.RawMaterials.AddAsync(rawMat3);
            await dbContext.InventoryRawMaterials.AddAsync(invenotryRawMat);
            await dbContext.InventoryRawMaterials.AddAsync(invenotryRawMat2);
            await dbContext.InventoryRawMaterials.AddAsync(invenotryRawMat3);

            await dbContext.SaveChangesAsync();


            var expected = await service.CheckRawMaterialsForProduceAsync(listColors, qty, inventory.Name);

            Assert.True(expected);
            Assert.False(expectedFalse);
        }

        [Fact]
        public async void TestCheckIfInventoryNameExistAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new InventoryService(dbContext, sanitizer, colorService, productService);

            var inventory = new Inventory()
            {
                Id = 1249124,
                Name = "Test"
            };

            var name = "Wrong test";

            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.SaveChangesAsync();

            var expected = await service.CheckIfInventoryNameExistAsync(inventory.Name);
            var expected2 = await service.CheckIfInventoryNameExistAsync(name);

            Assert.True(expected);
            Assert.False(expected2);
        }

        [Fact]
        public async void TestGetInventoryProductAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);

            var colorRepo = new Mock<IColorService>();

            var list = new List<Color>
            {
                new Color
                {
                    Id = 12312498,
                    Name = "test"
                }
            };
            colorRepo.Setup(x => x.GetAllColorsAsync()).Returns(Task.FromResult<IEnumerable<Color>>(list));
            var colorObject = colorRepo.Object;

            var productRepo = new Mock<IProductService>();

            var list2 = new List<string>();
            list2.Add("test");
            productRepo.Setup(x => x.GetAllProductTypesAsync()).Returns(Task.FromResult<List<string>>(list2));

            var productObject = productRepo.Object;

            var service = new InventoryService(dbContext, sanitizer, colorObject, productObject);

            var inventory = new Inventory()
            {
                Id = 1245124,
                Name = "Test"
            };

            var product = new Product()
            {
                Id = 21541243,
                ImgUrl = "asf",
                IsDeleted = false,
                Name = "Test",
                Price = 1M,
                Type = "test"
            };

            var inventProduct = new InventoryProduct()
            {
                ProductId = product.Id,
                InventoryId = inventory.Id
            };

            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.Products.AddAsync(product);
            await dbContext.InventoryProducts.AddAsync(inventProduct);
            await dbContext.SaveChangesAsync();


            var expected = await service.GetInventoryProductAsync();


            Assert.Equal(expected.Products.Where(x => x.ProductId == product.Id).FirstOrDefault(), inventProduct);
        }

        [Fact]
        public async void TestGetInventoryRawMaterialAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);

            var colorRepo = new Mock<IColorService>();

            var list = new List<Color>
            {
                new Color
                {
                    Id = 12312498,
                    Name = "test"
                }
            };
            colorRepo.Setup(x => x.GetAllColorsAsync()).Returns(Task.FromResult<IEnumerable<Color>>(list));
            var colorObject = colorRepo.Object;
            var service = new InventoryService(dbContext, sanitizer, colorObject, productService);

            var inventory = new Inventory()
            {
                Id = 8898323,
                Name = "Test"
            };
            var color = new Color()
            {
                Id = 99898213,
                Name = "test"
            };

            var rawMaterial = new RawMaterial()
            {
                Id = 99980098,
                ColorId = color.Id,
                Type = RawMaterialType.Warp,
            };

            var inventRawMat = new InventoryRawMaterial()
            {
                RawMaterialId = rawMaterial.Id,
                InventoryId = inventory.Id
            };

            await dbContext.Inventories.AddAsync(inventory);
            await dbContext.Colors.AddAsync(color);
            await dbContext.RawMaterials.AddAsync(rawMaterial);
            await dbContext.InventoryRawMaterials.AddAsync(inventRawMat);
            await dbContext.SaveChangesAsync();

            var expected = await service.GetInventoryRawMaterialAsync();

            Assert.True(expected.RawMaterials.Where(x => x.InventoryId == inventory.Id).FirstOrDefault() == inventRawMat);
        }
    }
}
