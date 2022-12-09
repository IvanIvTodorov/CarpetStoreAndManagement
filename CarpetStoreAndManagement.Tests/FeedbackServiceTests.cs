using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Services.Services;
using CarpetStoreAndManagement.ViewModels.FeedbackViewModels;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Tests
{
    public class FeedbackServiceTests
    {

        [Fact]
        public async void TestGetAllFeedbacksAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new FeedbackService(dbContext, sanitizer);

            var feedback = new Feedback()
            {
                Email = "test@abv.bg",
                FullName = "Test",
                Message = "TestTest"
            };

            dbContext.Feedbacks.Add(feedback);

            dbContext.SaveChanges();

            var result = await service.GetAllFeedbacksAsync();

            Assert.NotNull(result);
            Assert.True(result.Count() == 1);
        }

        [Fact]
        public async void TestSubmitFeedbackAsync()
        {
            var sanitizer = new HtmlSanitizer();
            var options = new DbContextOptionsBuilder<CarpetStoreAndManagementDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new CarpetStoreAndManagementDbContext(options);
            var service = new FeedbackService(dbContext, sanitizer);

            var feedback = new FeedbackViewModel()
            {
                Email = "test2@abv.bg",
                FullName = "Test2",
                Message = "TestTest2"
            };

            await service.SubmitFeedbackAsync(feedback);

            var result = await dbContext.Feedbacks.ToListAsync();

            Assert.True(result.Count() == 2);
        }
    }
}
