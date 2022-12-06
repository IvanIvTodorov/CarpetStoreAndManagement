using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProduceViewModel model)
        {
            await inventoryService.AddInventoryAsync(model.InventoryName);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await inventoryService.GetAllItemsAsync();

            return View(model);
        }

        public async Task<IActionResult> Products()
        {
            var model = await inventoryService.GetInventoryProductAsync();

            return View(model);
        }

        public async Task<IActionResult> RawMaterials()
        {
            var model = await inventoryService.GetInventoryRawMaterialAsync();

            return View(model);
        }
    }
}
