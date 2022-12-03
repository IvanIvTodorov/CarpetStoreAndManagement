using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.FeedbackViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult LeaveFeedback()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubmitFeedback(FeedbackViewModel model)
        {
            await feedbackService.SubmitFeedbackAsync(model);

            TempData["message"] = $"Your feedback has been submitted!!!";       

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AllFeedbacks()
        {
            var model = await feedbackService.GetAllFeedbacksAsync();

            return View(model);
        }
    }
}
