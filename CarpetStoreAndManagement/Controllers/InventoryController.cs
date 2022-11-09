using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            this.inventoryService = inventoryService;
        }

        public async Task<IActionResult> Add(ProduceViewModel model)
        {
            await inventoryService.AddInventoryAsync(model.InventoryName);

            return RedirectToAction("Produce", "Product"); 
        }

        public IActionResult All()
        {
            return View();
        }
    }
}
