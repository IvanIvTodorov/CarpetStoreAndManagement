using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpetStoreAndManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RawMaterialController : Controller
    {
        private readonly IRawMaterialService rawMaterialService;
        private readonly IInventoryService inventoryService;
        private readonly IColorService colorService;
        private const int minQuantity = 1;

        public RawMaterialController(IRawMaterialService rawMaterialService, IInventoryService inventoryService, IColorService colorService)
        {
            this.rawMaterialService = rawMaterialService;
            this.inventoryService = inventoryService;
            this.colorService = colorService;
        }

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

        [HttpPost]
        public async Task<IActionResult> Order(AddRawMaterialViewModel model, string type)
        {
            if (!ModelState.IsValid)
            {
                if (model.Quantity < minQuantity)
                {
                    TempData["message"] = "Quantity should be higher than 0!";
                }

                if (model.Color == null)
                {
                    TempData["message"] = "Color is required!";
                }
            }
            else if (!await colorService.CheckColorExistAsync(model.Color))
            {
                TempData["message"] = "Invalid color!";
            }
            else if (Enum.TryParse(type, true, out RawMaterialType typeParsed) == false)
            {
                TempData["message"] = "Invalid raw material type!";
            }
            else
            {
                await rawMaterialService.AddRawMaterialAsync(model, typeParsed);

            }

            return RedirectToAction(nameof(Show));
        }
    }
}
