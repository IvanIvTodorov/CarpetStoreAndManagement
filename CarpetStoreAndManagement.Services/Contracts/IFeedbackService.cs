using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.ViewModels.FeedbackViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IFeedbackService
    {
        Task SubmitFeedbackAsync(FeedbackViewModel model);
        Task<IEnumerable<FeedbackViewModel>> GetAllFeedbacksAsync();
    }
}
