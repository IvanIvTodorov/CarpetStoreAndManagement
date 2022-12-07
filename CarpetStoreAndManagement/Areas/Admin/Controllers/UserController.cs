using CarpetStoreAndManagement.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
           this.userService = userService;
        }
        public async Task<IActionResult> All()
        {
            var model = await userService.GetAllUsers();

            return View(model);
        }

        public IActionResult AddAdmin()
        {

            return View(nameof(All));
        }
    }
}
