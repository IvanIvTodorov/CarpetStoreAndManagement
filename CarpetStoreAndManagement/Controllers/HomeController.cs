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
    }
}