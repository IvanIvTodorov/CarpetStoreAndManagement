using CarpetStoreAndManagement.CustomRoles;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarpetStoreAndManagement.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await productService.GetAllProductsAsync();

            return View(model);
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string? userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await productService.GetAllProductsInCartAsync(userId);

            return View(model);
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpGet]
        public async Task<IActionResult> AddToCart(int productId)
        {
            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = $"This product do not exist!";
                return RedirectToAction(nameof(All));
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await productService.AddProductToCartAsync(productId, userId);

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpPost]
        public async Task<IActionResult> IncreaseProductQuantityInCart(int productId)
        {
            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = $"This product do not exist!";
                return RedirectToAction(nameof(All));
            }
            await productService.IncreaseProductQtyInCartAsync(productId);

            return RedirectToAction(nameof(Cart));
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpPost]
        public async Task<IActionResult> DecreaseProductQuantityInCart(int productId)
        {
            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = $"This product do not exist!";
                return RedirectToAction(nameof(All));
            }

            var userProduct = await productService.GetCurrentUserProduct(productId);

            if (userProduct.Quantity <= requiredQuantity)
            {
                TempData["message"] = $"Quantity must not be zero or negative number!";
                return RedirectToAction(nameof(Cart));
            }

            await productService.DecreaseProductQtyInCartAsync(productId);

            return RedirectToAction(nameof(Cart));
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = $"This product do not exist!";
                return RedirectToAction(nameof(All));
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await productService.RemoveFromCartAsync(productId, userId);

            return RedirectToAction(nameof(Cart));
        }
    }
}
