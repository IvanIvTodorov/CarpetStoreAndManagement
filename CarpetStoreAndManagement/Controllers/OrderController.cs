using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.OrderViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarpetStoreAndManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IInventoryService inventoryService;

        public OrderController(IOrderService orderService, IProductService productService, IInventoryService inventoryService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.inventoryService = inventoryService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrder(bool model)
        {
            if (!model)
            {
                TempData["message"] = $"Your cart is empty!";

                return RedirectToAction("Cart", "Product");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await orderService.MakeOrderAsync(userId);

            return RedirectToAction("All", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            string? userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await orderService.GetMyOrdersAsync(userId);

            return View(model);
        }
    }
}
