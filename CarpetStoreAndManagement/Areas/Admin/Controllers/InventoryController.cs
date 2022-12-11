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
        private const string InventoryConstraint = "Inventory name should be with minimum length 3 and maximum length 25!";
        private const string InventoryAdded = "You have added new inventory!";
        private const string InvalidSearchParams = "Invalid search parameters!";
        private const string InventoryAlreadyExists = "Inventory with such name already exists!";

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
            var exists = await inventoryService.CheckIfInventoryNameExistAsync(model.InventoryName);
            if (exists)
            {
                TempData["message"] = InventoryAlreadyExists;
                return RedirectToAction(nameof(All));
            }

            if (model.InventoryName == null || model.InventoryName == "" || model.InventoryName.Length < 3 || model.InventoryName.Length > 25)
            {
                TempData["message"] = InventoryConstraint;
            }
            else
            {
                TempData["message"] = InventoryAdded;

                await inventoryService.AddInventoryAsync(model.InventoryName);
            }
            
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
            if (!ModelState.IsValid)
            {
                TempData["message"] = InvalidSearchParams;

            }

            var passModel = await productService.GetProductsInInventoryBySearchAsync(model);

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
            if (!ModelState.IsValid)
            {
                TempData["message"] = InvalidSearchParams;

            }
            var passModel = await rawMaterialService.GetRawMatInInventoryBySearchAsync(model);

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
