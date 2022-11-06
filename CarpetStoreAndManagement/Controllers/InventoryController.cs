using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
