using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InventoryController : Controller
    {
        private readonly IInventoryService inventoryService;
        private readonly IProductService productService;
        private readonly IColorService colorService;
        private readonly IRawMaterialService rawMaterialService;

        public InventoryController(IInventoryService inventoryService, IProductService productService, IColorService colorService, IRawMaterialService rawMaterialService)
        {
            this.inventoryService = inventoryService;
            this.productService = productService;
            this.colorService = colorService;
            this.rawMaterialService = rawMaterialService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(ProduceViewModel model)
        {
            await inventoryService.AddInventoryAsync(model.InventoryName);

            return RedirectToAction(nameof(All));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await inventoryService.GetAllItemsAsync();

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var model = await inventoryService.GetInventoryProductAsync();

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> RawMaterials()
        {
            var model = await inventoryService.GetInventoryRawMaterialAsync();

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RawMaterialsBySearch(RawMaterialsInInventoryViewModel model)
        {
            var passModel = await rawMaterialService.GetRawMatInInventoryBySearch(model);

            var passModell = new RawMaterialsInInventoryViewModel()
            {
                RawMaterials = passModel,
                Inventories = await inventoryService.GetInventoriesAsync(),
                Types = Enum.GetNames(typeof(RawMaterialType)).ToList(),
                Colors = await colorService.GetAllColorsAsync()
            };

            return View(nameof(RawMaterials), passModell);
        }
    }
}
