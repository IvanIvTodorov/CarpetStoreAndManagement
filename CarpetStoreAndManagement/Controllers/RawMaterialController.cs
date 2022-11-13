using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Controllers
{
    public class RawMaterialController : Controller
    {
        private readonly IRawMaterialService rawMaterialService;
        private readonly IInventoryService inventoryService;
        private const int minQuantity = 1;

        public RawMaterialController(IRawMaterialService rawMaterialService, IInventoryService inventoryService)
        {
            this.rawMaterialService = rawMaterialService;
            this.inventoryService = inventoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Show()
        {
            var model = new AddRawMaterialViewModel()
            {
                Inventories = await inventoryService.GetInventoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Order(AddRawMaterialViewModel model, string type)
        {
            if (!ModelState.IsValid)
            {
                if (model.Quantity < minQuantity)
                {
                    TempData["message"] = "Quantity should be higher than 0!";
                }

                if (model.Color == null)
                {
                    TempData["message"] = "Color is required!";
                }

                return RedirectToAction(nameof(Show));
            }

            await rawMaterialService.AddRawMaterialAsync(model, type);

            return RedirectToAction(nameof(Show));
        }
    }
}
