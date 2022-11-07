using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarpetStoreAndManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await productService.GetAllProductsAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddProductViewModel();

            return View(model);
        }

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

        [HttpGet]
        public async Task<IActionResult> Details(int productId)
        {
            var model = await productService.ProductDetailsAsync(productId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await productService.RemoveProductAsync(productId);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

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
            await productService.DecreaseProductQtyInCartAsync(productId);

            return RedirectToAction(nameof(Cart));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart (int productId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await productService.RemoveFromCartAsync(productId, userId);

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult> Produce()
        {
            var model = new ProduceViewModel()
            {
                Products = await productService.GetProductsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Produce(ProduceViewModel model, int productId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Produce));
            };

            await productService.ProduceProduct(model, productId);

            return RedirectToAction(nameof(Produce));
        }
    }
}
