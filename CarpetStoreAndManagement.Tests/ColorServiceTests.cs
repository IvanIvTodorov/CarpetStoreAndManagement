﻿using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Services.Services;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace CarpetStoreAndManagement.Tests
{
    public class ColorServiceTests
    {
        [Fact]
        public void TestIfColorExist()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ColorService(dbContext, sanitizer);

            var color = new Color
            {
                Name = "Test"
            };

            dbContext.Colors.Add(color);

            dbContext.SaveChanges();

            var success = service.CheckColorExistAsync("Test").Result;

            Assert.True(success);
        }

        [Fact]
        public void TestGetAllColorAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ColorService(dbContext, sanitizer);

            var color = new Color
            {
                Name = "Test2"
            };

            var color2 = new Color
            {
                Name = "Yelllllowww"
            };

            dbContext.Colors.Add(color);
            dbContext.Colors.Add(color2);

            dbContext.SaveChanges();

            var success = service.GetAllColorsAsync().Result;

            Assert.True(success.Any(x => x.Name == color.Name));
            Assert.True(success.Any(x => x.Name == color2.Name));
        }


        [Fact]
        public async void TestAddColorAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new ColorService(dbContext, sanitizer);

            var color = new Color
            {
                Name = "Test5"
            };

            await service.AddColorAsync("Test5");

            Assert.True(dbContext.Colors.Any(x => x.Name == "Test5"));
        }
    }
}
