using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RawMaterialController : Controller
    {
        private readonly IRawMaterialService rawMaterialService;
        private readonly IInventoryService inventoryService;
        private readonly IColorService colorService;
        private const int MinQuantity = 1;
        private const string QuantityConstraint = "Quantity should be higher than 0!";
        private const string ColorConstraint = "Color is required!";
        private const string InvalidColor = "Invalid color!";
        private const string InvalidRawMaterialType = "Invalid raw material type!";

        public RawMaterialController(IRawMaterialService rawMaterialService, IInventoryService inventoryService, IColorService colorService)
        {
            this.rawMaterialService = rawMaterialService;
            this.inventoryService = inventoryService;
            this.colorService = colorService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Show()
        {
            var model = new AddRawMaterialViewModel()
            {
                Inventories = await inventoryService.GetInventoriesAsync(),
                Colors = await colorService.GetAllColorsAsync()
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Order(AddRawMaterialViewModel model, string type)
        {
            if (!ModelState.IsValid)
            {
                if (model.Quantity < MinQuantity)
                {
                    TempData["message"] = QuantityConstraint;
                }

                if (model.Color == null)
                {
                    TempData["message"] = ColorConstraint;
                }
            }
            else if (!await colorService.CheckColorExistAsync(model.Color))
            {
                TempData["message"] = InvalidColor;
            }
            else if (Enum.TryParse(type, true, out RawMaterialType typeParsed) == false)
            {
                TempData["message"] = InvalidRawMaterialType;
            }
            else
            {
                await rawMaterialService.AddRawMaterialAsync(model, typeParsed);
                TempData["message"] = $"{model.Quantity} pieces of {model.Color.ToLower()} {type.ToLower()} are delivered in {model.InventoryName} inventory !";

            }

            return RedirectToAction(nameof(Show));
        }
    }
}
