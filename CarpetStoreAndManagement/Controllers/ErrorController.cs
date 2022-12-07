using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult PageNotFound()
        {
            return View();
        }

        [HttpGet]
        [Route("Error/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
