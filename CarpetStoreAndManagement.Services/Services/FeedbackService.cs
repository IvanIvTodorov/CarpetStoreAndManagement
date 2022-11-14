using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.FeedbackViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly CarpetStoreAndManagementDbContext context;

        public FeedbackService(CarpetStoreAndManagementDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<FeedbackViewModel>> GetAllFeedbacksAsync()
        {
            var feedbacks = await context.Feedbacks.ToListAsync();

            var feedbacksViewModel = new List<FeedbackViewModel>();

            foreach (var feedback in feedbacks)
            {
                feedbacksViewModel.Add(new FeedbackViewModel
                {
                    Id = feedback.Id,
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
                Email = model.Email,
                Message = model.Message,
                FullName = model.FullName
            };

            await context.Feedbacks.AddAsync(feedback);
            await context.SaveChangesAsync();
        }
    }
}
