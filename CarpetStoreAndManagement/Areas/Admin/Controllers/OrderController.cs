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
        private const int RequiredQuantity = 1;
        private const int MinimumQuantity = 0;
        private const string InvalidOrder = "Invalid order!";
        private const string InvalidProduct = "Invalid product!";
        private const string OrderSent = "Order has been sent !";
        private const string QuantityConstraint = "Quantity should be higher than 0!";

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
            if (!await orderService.CheckIfOrderExistAsync(orderId))
            {
                TempData["message"] = InvalidOrder;

                return RedirectToAction(nameof(Orders));
            }
            var missingProducts = await orderService.CompleteOrderAsync(orderId);

            if (missingProducts.Count() > MinimumQuantity)
            {
                TempData["message"] = $"You need to produce more from {String.Join(", ", missingProducts.Select(x => x.Name).ToArray())}";

                return RedirectToAction(nameof(Orders));
            }

            TempData["message"] = OrderSent;

            return RedirectToAction(nameof(Orders));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> ProduceFromOrder(int orderId)
        {
            if (!await orderService.CheckIfOrderExistAsync(orderId))
            {
                TempData["message"] = InvalidOrder;
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
                if (model.Quantity < RequiredQuantity)
                {
                    TempData["message"] = QuantityConstraint;
                    return RedirectToAction(nameof(Produce));
                }
            };

            if (!await productService.ProductIdExistAsync(productId))
            {
                TempData["message"] = InvalidProduct;
                return RedirectToAction(nameof(Produce));

            }

            var productColors = await productService.GetProductColorsAsync(productId);

            if (!await inventoryService.CheckRawMaterialsForProduceAsync(productColors, model.Quantity, model.InventoryName))
            {
                TempData["message"] = $"You do not have enough raw materials in {model.InventoryName} inventory! You need to order {String.Join(" ", productColors)} raw materials!";

                return RedirectToAction("Show", "RawMaterial");
            }

            TempData["message"] = $"{model.Quantity} pieces are added in {model.InventoryName} inventory!";

            await productService.ProduceProductAsync(model, productId);
            await inventoryService.DecreaseUsedRawMaterialsInInventoryAsync(productColors, model.Quantity, model.InventoryName);

            return RedirectToAction(nameof(Orders));
        }
    }
}
