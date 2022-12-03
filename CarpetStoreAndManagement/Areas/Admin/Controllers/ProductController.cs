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

            var productColors = await productService.GetProductColors(productId);

            if (!await inventoryService.CheckRawMaterialsForProduce(productColors, model.Quantity, model.InventoryName))
            {
                TempData["message"] = $"You do not have enough raw materials in {model.InventoryName} inventory! You need to order {String.Join(" and ", productColors)} raw materials!";

                return RedirectToAction("Show", "RawMaterial");
            }

            await productService.ProduceProduct(model, productId);
            await inventoryService.DecreaseUsedRawMaterialsInInventory(productColors, model.Quantity, model.InventoryName);


            return RedirectToAction(nameof(Produce));
        }
    }
}
