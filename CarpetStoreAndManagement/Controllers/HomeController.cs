using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CarpetStoreAndManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {        
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}