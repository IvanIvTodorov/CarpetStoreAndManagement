using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.FeedbackViewModels;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace CarpetStoreAndManagement.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly CarpetStoreAndManagementDbContext context;
        private readonly HtmlSanitizer sanitizer;

        public FeedbackService(CarpetStoreAndManagementDbContext context, HtmlSanitizer sanitizer)
        {
            this.context = context;
            this.sanitizer = sanitizer;
        }

        public async Task<IEnumerable<FeedbackViewModel>> GetAllFeedbacksAsync()
        {
            var feedbacks = await context.Feedbacks.ToListAsync();

            var feedbacksViewModel = new List<FeedbackViewModel>();

            foreach (var feedback in feedbacks)
            {
                feedbacksViewModel.Add(new FeedbackViewModel
                {
                    Email = feedback.Email,
                    FullName = feedback.FullName,
                    Message = feedback.Message
                });
            }

            return feedbacksViewModel;
        }

        public async Task SubmitFeedbackAsync(FeedbackViewModel model)
        {
            var feedback = new Feedback()
            {
                Email = sanitizer.Sanitize(model.Email),
                Message = sanitizer.Sanitize(model.Message),
                FullName = sanitizer.Sanitize(model.FullName)
            };

            await context.Feedbacks.AddAsync(feedback);
            await context.SaveChangesAsync();
        }
    }
}
