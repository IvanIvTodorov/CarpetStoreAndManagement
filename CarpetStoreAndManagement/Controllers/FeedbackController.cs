using CarpetStoreAndManagement.CustomRoles;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.FeedbackViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpGet]
        public IActionResult LeaveFeedback()
        {
            return View();
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpPost]
        public async Task<IActionResult> SubmitFeedback(FeedbackViewModel model)
        {
            await feedbackService.SubmitFeedbackAsync(model);

            TempData["message"] = $"Your feedback has been submitted!!!";       

            return RedirectToAction("Index", "Home");
        }
    }
}
