using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Controllers
{
    public class RawMaterialController : Controller
    {
        private readonly IRawMaterialService rawMaterialService;

        public RawMaterialController(IRawMaterialService rawMaterialService)
        {
            this.rawMaterialService = rawMaterialService;
        }

        [HttpGet]
        public IActionResult Show()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(AddRawMaterialViewModel model, string type)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Show));
            }

            await rawMaterialService.AddProductAsync(model, type);

            return View(nameof(Show));
        }
    }
}
