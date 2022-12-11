using CarpetStoreAndManagement.CustomRoles;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.OrderViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarpetStoreAndManagement.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private const string EmptyCart = "Your cart is empty!";
        private const string SubmittedOrder = $"Your order has been submitted!";

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpPost]
        public async Task<IActionResult> MakeOrder(bool model)
        {
            if (!model)
            {
                TempData["message"] = EmptyCart;

                return RedirectToAction("Cart", "Product");
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            await orderService.MakeOrderAsync(userId);

            TempData["message"] = SubmittedOrder;


            return RedirectToAction("All", "Product");
        }

        [Authorize(Roles = CustomRole.AdminOrUser)]
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            string? userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var model = await orderService.GetMyOrdersAsync(userId);

            return View(model);
        }
    }
}
