using CarpetStoreAndManagement.ViewModels.FeedbackViewModels;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IFeedbackService
    {
        Task SubmitFeedbackAsync(FeedbackViewModel model);
        Task<IEnumerable<FeedbackViewModel>> GetAllFeedbacksAsync();
    }
}
