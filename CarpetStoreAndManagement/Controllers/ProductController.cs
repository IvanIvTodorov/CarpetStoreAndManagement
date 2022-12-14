using CarpetStoreAndManagement.CustomRoles;
using CarpetStoreAndManagement.Services.Contracts;
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
        private const int RequiredQuantity = 1;
        private const string TypeDoNotExist = "This type do not exist!";
        private const string ProductDoNotExist = "This product do not exist!";
        private const string QuantityConstraint = "Quantity must not be zero or negative number!";
        private const string SuccessfullAdd = "Successfully added to shoping cart!";

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
                TempData["message"] = TypeDoNotExist;

                return RedirectToAction(nameof(All));
            }

            var model = await productService.GetProductsByTypeAsync(type);

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int productId)
        {
            if (!await productService.ProductIdExistAsync(productId))
            {
                TempData["message"] = ProductDoNotExist;
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
            if (!await productService.ProductIdExistAsync(productId))
            {
                TempData["message"] = ProductDoNotExist;
                return RedirectToAction(nameof(All));
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await productService.AddProductToCartAsync(productId, userId);
            TempData["message"] = SuccessfullAdd;

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpPost]
        public async Task<IActionResult> IncreaseProductQuantityInCart(int productId)
        {
            if (!await productService.ProductIdExistAsync(productId))
            {
                TempData["message"] = ProductDoNotExist;
                return RedirectToAction(nameof(All));
            }
            await productService.IncreaseProductQtyInCartAsync(productId);

            return RedirectToAction(nameof(Cart));
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpPost]
        public async Task<IActionResult> DecreaseProductQuantityInCart(int productId)
        {
            if (!await productService.ProductIdExistAsync(productId))
            {
                TempData["message"] = ProductDoNotExist;
                return RedirectToAction(nameof(All));
            }

            var userProduct = await productService.GetCurrentUserProductAsync(productId);

            if (userProduct.Quantity <= RequiredQuantity)
            {
                TempData["message"] = QuantityConstraint;
                return RedirectToAction(nameof(Cart));
            }

            await productService.DecreaseProductQtyInCartAsync(productId);

            return RedirectToAction(nameof(Cart));
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            if (!await productService.ProductIdExistAsync(productId))
            {
                TempData["message"] = ProductDoNotExist;
                return RedirectToAction(nameof(All));
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await productService.RemoveFromCartAsync(productId, userId);

            return RedirectToAction(nameof(Cart));
        }
    }
}
