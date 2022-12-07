using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService inventoryService;
        private readonly IProductService productService;
        private readonly IColorService colorService;

        public InventoryController(IInventoryService inventoryService, IProductService productService, IColorService colorService)
        {
            this.inventoryService = inventoryService;
            this.productService = productService;
            this.colorService = colorService;
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

        public async Task<IActionResult> ProductsBySearch(ProductsInInventoryViewModel model)
        {
            var passModel = await productService.GetProductsInInventoryBySearch(model);

            var passModell = new ProductsInInventoryViewModel()
            {
                Products = passModel,
                Inventories = await inventoryService.GetInventoriesAsync(),
                Types = await productService.GetAllProductTypesAsync(),
                Colors = await colorService.GetAllColorsAsync()
            };

            return View(nameof(Products), passModell);
        }

        //public async Task<IActionResult> RawMaterialsBySearch(RawMaterialsInInventoryViewModel model)
        //{
        //    var model = new object();

        //    return View(nameof(RawMaterials), new { model });
        //}
    }
}
