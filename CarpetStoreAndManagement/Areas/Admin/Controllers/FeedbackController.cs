using CarpetStoreAndManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<IActionResult> AllFeedbacks()
        {
            var model = await feedbackService.GetAllFeedbacksAsync();

            return View(model);
        }
    }
}
