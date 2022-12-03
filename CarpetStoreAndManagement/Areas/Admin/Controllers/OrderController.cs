using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
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
    }
}
