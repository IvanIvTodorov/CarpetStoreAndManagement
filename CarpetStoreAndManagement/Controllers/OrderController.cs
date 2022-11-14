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
        public async Task<IActionResult> Orders()
        {
            var model = await orderService.GetAllOrdersAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(int orderId)
        {
            var orders = await orderService.CompleteOrderAsync(orderId);

            if (orders.Count() > 0)
            {
                TempData["message"] = $"You need to produce more from {String.Join(", ", orders.Select(x => x.Name).ToArray())}";

                return RedirectToAction("Orders", "Order");
            }


            return RedirectToAction(nameof(Orders));
        }

        [HttpPost]
        public async Task<IActionResult> ProduceFromOrder(int orderId)
        {
            var model = new ProduceViewModel()
            {
                Products = await productService.GetProductsFromOrderAsync(orderId),
                Inventories = await inventoryService.GetInventoriesAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await orderService.GetMyOrdersAsync(userId);

            return View(model);
        }
    }
}
