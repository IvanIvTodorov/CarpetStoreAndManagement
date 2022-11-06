using CarpetStoreAndManagement.Services.Contracts;
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

        public async Task<IActionResult> MakeOrder()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await orderService.MakeOrderAsync(userId);

            return RedirectToAction("All", "Product");
        }
    }
}
