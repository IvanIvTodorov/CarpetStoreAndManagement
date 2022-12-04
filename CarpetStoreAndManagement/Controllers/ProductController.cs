using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarpetStoreAndManagement.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await productService.GetAllProductsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int productId)
        {
            var model = await productService.ProductDetailsAsync(productId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string? userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await productService.GetAllProductsInCartAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await productService.AddProductToCartAsync(productId, userId);

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> IncreaseProductQuantityInCart(int productId)
        {
            await productService.IncreaseProductQtyInCartAsync(productId);

            return RedirectToAction(nameof(Cart));
        }
        [HttpPost]
        public async Task<IActionResult> DecreaseProductQuantityInCart(int productId)
        {
            var userProduct = await productService.GetCurrentUserProduct(productId);

            if (userProduct.Quantity <= requiredQuantity)
            {
                TempData["message"] = $"Quantity must not be zero or negative number!";
                return RedirectToAction(nameof(Cart));
            }

            await productService.DecreaseProductQtyInCartAsync(productId);

            return RedirectToAction(nameof(Cart));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await productService.RemoveFromCartAsync(productId, userId);

            return RedirectToAction(nameof(Cart));
        }
    }
}
