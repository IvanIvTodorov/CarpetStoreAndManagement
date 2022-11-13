using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.OrderViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarpetStoreAndManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> MakeOrder()
        {
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

        public async Task<IActionResult> CompleteOrder(int orderId)
        {
            var orders = await orderService.CompleteOrderAsync(orderId);

            if (orders.Count() > 0)
            {
                TempData["message"] = $"You need to produce more from {String.Join(", ", orders.Select(x => x.Name).ToArray())}";

                return RedirectToAction("Produce", "Product");
            }


            return RedirectToAction(nameof(Orders));
        }
    }
}
