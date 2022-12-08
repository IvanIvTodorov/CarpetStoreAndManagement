using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IInventoryService inventoryService;
        private const int requiredQuantity = 1;

        public OrderController(IOrderService orderService, IProductService productService, IInventoryService inventoryService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.inventoryService = inventoryService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var model = await orderService.GetAllOrdersAsync();

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CompleteOrder(int orderId)
        {
            if (!await orderService.CheckIfOrderExist(orderId))
            {
                TempData["message"] = "Invalid order!";

                return RedirectToAction(nameof(Orders));
            }
            var orders = await orderService.CompleteOrderAsync(orderId);

            if (orders.Count() > 0)
            {
                TempData["message"] = $"You need to produce more from {String.Join(", ", orders.Select(x => x.Name).ToArray())}";

                return RedirectToAction(nameof(Orders));
            }


            return RedirectToAction(nameof(Orders));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ProduceFromOrder(int orderId)
        {
            if (!await orderService.CheckIfOrderExist(orderId))
            {
                TempData["message"] = "Invalid order!";
                return RedirectToAction(nameof(Orders));

            }

            var model = await orderService.SetProduceFromOrderViewModelAsync(orderId);

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Produce(ProduceFromOrderViewModel model, int productId, int orderId)
        {

            if (!ModelState.IsValid)
            {
                if (model.Quantity < requiredQuantity)
                {
                    TempData["message"] = "Quantity should be higher than 0!";
                    return RedirectToAction(nameof(Produce));
                }
            };

            if (!await productService.ProductIdExist(productId))
            {
                TempData["message"] = "Invalid product!";
                return RedirectToAction(nameof(Produce));

            }

            var productColors = await productService.GetProductColors(productId);

            if (!await inventoryService.CheckRawMaterialsForProduce(productColors, model.Quantity, model.InventoryName))
            {
                TempData["message"] = $"You do not have enough raw materials in {model.InventoryName} inventory! You need to order {String.Join(" ", productColors)} raw materials!";

                return RedirectToAction("Show", "RawMaterial");
            }

            await productService.ProduceProduct(model, productId);
            await inventoryService.DecreaseUsedRawMaterialsInInventory(productColors, model.Quantity, model.InventoryName);

            return RedirectToAction(nameof(Orders));
        }
    }
}
