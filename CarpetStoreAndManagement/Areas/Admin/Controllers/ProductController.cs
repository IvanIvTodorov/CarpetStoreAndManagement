using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IInventoryService inventoryService;
        private const int requiredQuantity = 1;
        private const int notValidOrderId = 0;

        public ProductController(IProductService productService, IInventoryService inventoryService)
        {
            this.productService = productService;
            this.inventoryService = inventoryService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await productService.GetAllProductsAsync();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> ShowByType(string type)
        {
            if (!await productService.CheckIfTypeExistAsync(type))
            {
                TempData["message"] = $"This type do not exist!";

                return RedirectToAction(nameof(All));
            }

            var model = await productService.GetProductsByTypeAsync(type);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddProductViewModel();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await productService.AddProductAsync(model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Something went wrong!");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = "Invalid product!";
                return RedirectToAction(nameof(All));
            }

            await productService.RemoveProductAsync(productId);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Produce()
        {
            var model = new ProduceViewModel();

            model.Inventories = await inventoryService.GetInventoriesAsync();
            model.Products = await productService.GetProductsAsync();
            model.Types = await productService.GetAllProductTypesAsync();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Produce(ProduceViewModel model, int productId)
        {

            if (!ModelState.IsValid)
            {
                if (model.Quantity < requiredQuantity)
                {
                    TempData["message"] = "Quantity should be higher than 0!";
                    return RedirectToAction(nameof(Produce));
                }
            };

            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = "Invalid product!";
                return RedirectToAction(nameof(Produce));
            }

            var productColors = await productService.GetProductColors(productId);

            if (!await inventoryService.CheckRawMaterialsForProduce(productColors, model.Quantity, model.InventoryName))
            {
                TempData["message"] = $"You do not have enough raw materials in {model.InventoryName} inventory! You need to order {String.Join(" ", productColors)} raw materials!";

                return RedirectToAction("Show", "RawMaterial");
            }

            await productService.ProduceProduct(model, productId);
            await inventoryService.DecreaseUsedRawMaterialsInInventory(productColors, model.Quantity, model.InventoryName);

            return RedirectToAction("Products", "Inventory");
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditPage(int productId)
        {
            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = "Invalid product!";

                return RedirectToAction(nameof(All));
            }
            var model = await productService.EditProductAsync(productId);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(All));
            }

            var id = await productService.EditProductAsync(model);

            return RedirectToAction(nameof(Details), new { productId = id });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> SearchByType(string type)
        {
            var types = await productService.GetProductsByTypeAsync(type);

            var model = new ProduceViewModel()
            {
                Products = await productService.PorductsByTypeAsync(type),
                Inventories = await inventoryService.GetInventoriesAsync(),
                Types = await productService.GetAllProductTypesAsync(),
            };

            return View(nameof(Produce), model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Details(int productId)
        {
            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = $"This product do not exist!";
                return RedirectToAction(nameof(All));
            }
            var model = await productService.ProductDetailsAsync(productId);

            return View(model);
        }
    }
}
