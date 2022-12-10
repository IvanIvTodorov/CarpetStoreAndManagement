using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Controllers
{
    public class ErrorController : Controller
    {
        private readonly IErrorService errorService;
        public ErrorController(IErrorService errorService)
        {
            this.errorService = errorService;
        }
        [Route("Error/{statusCode}")]
        public IActionResult ErrorPage(int statusCode)
        {
            var model = new ErrorViewModel()
            {
                StatusCode = statusCode,
                ErrorMessage = errorService.GetError(statusCode)

            };
            return View(model);
        }

        [HttpGet]
        [Route("Error/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
