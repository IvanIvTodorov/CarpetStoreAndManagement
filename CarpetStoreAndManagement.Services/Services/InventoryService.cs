using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;


namespace CarpetStoreAndManagement.Services.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly CarpetStoreAndManagementDbContext context;
        private readonly HtmlSanitizer sanitizer;
        private readonly IColorService colorService;
        private readonly IProductService productService;
        private const int requiredMaterials = 3;

        public InventoryService(CarpetStoreAndManagementDbContext context, HtmlSanitizer sanitizer, IColorService colorService, IProductService productService)
        {
            this.context = context;
            this.sanitizer = sanitizer;
            this.colorService = colorService;
            this.productService = productService;
        }

        public async Task AddInventoryAsync(string name)
        {
            var sanitizedName = sanitizer.Sanitize(name);
            if (!context.Inventories.Any(x => x.Name == sanitizedName))
            {
                var invent = new Inventory()
                {
                    Name = sanitizedName
                };

                await context.Inventories.AddAsync(invent);
                await context.SaveChangesAsync();
            }
        }

        public async Task<AllInventoryViewModel> GetAllItemsAsync()
        {
            var products = await context.InventoryProducts
                .Include(x => x.Inventory)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .ToListAsync();
            var rawMaterials = await context.InventoryRawMaterials
                .Include(x => x.Inventory)
                .Include(x => x.RawMaterial)
                .ThenInclude(x => x.Color)
                .ToListAsync();

            return new AllInventoryViewModel()
            {
                Products = products,
                RawMaterials = rawMaterials
            };
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
        {
           var result = await context.Inventories.ToListAsync();

            return result;    
        }

        public async Task<bool> CheckRawMaterialsForProduceAsync(List<string> colors, int qty, string inventoryName)
        {
            var flag = false;

            foreach (var color in colors)
            {
                if (context.InventoryRawMaterials
                   .Include(x => x.Inventory)
                   .Include(x => x.RawMaterial)
                   .ThenInclude(x => x.Color)
                   .Where(x => x.RawMaterial.Color.Name == color && x.Inventory.Name == inventoryName)
                   .Count() == requiredMaterials)
                {
                    flag = true;

                    var rawMaterial = await context.InventoryRawMaterials
                   .Include(x => x.Inventory)
                   .Include(x => x.RawMaterial)
                   .ThenInclude(x => x.Color)
                   .Where(x => x.RawMaterial.Color.Name == color && x.Inventory.Name == inventoryName)
                   .FirstOrDefaultAsync();

                    if (rawMaterial == null || rawMaterial.Quantity < qty)
                    {
                        flag = false;
                        break;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public async Task DecreaseUsedRawMaterialsInInventoryAsync(List<string> colors, int qty, string inventoryName)
        {
            foreach (var color in colors)
            {
                var rawMaterial = await context.InventoryRawMaterials
               .Include(x => x.Inventory)
               .Include(x => x.RawMaterial)
               .ThenInclude(x => x.Color)
               .Where(x => x.RawMaterial.Color.Name == color && x.Inventory.Name == inventoryName)
               .ToListAsync();

                foreach (var item in rawMaterial)
                {
                    item.Quantity -= qty;
                }
            }

            await context.SaveChangesAsync();
        }

        public async Task<ProductsInInventoryViewModel> GetInventoryProductAsync()
        {
            var products = await context.InventoryProducts
                .Include(x => x.Inventory)
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .ToListAsync();

            var model = new ProductsInInventoryViewModel()
            {
                Products = products,
                Inventories = await GetInventoriesAsync(),
                Colors = await colorService.GetAllColorsAsync(),
                Types = await productService.GetAllProductTypesAsync()
            };

            return model;
        }

        public async Task<RawMaterialsInInventoryViewModel> GetInventoryRawMaterialAsync()
        {
            var rawMaterials = await context.InventoryRawMaterials
               .Include(x => x.Inventory)
               .Include(x => x.RawMaterial)
               .ThenInclude(x => x.Color)
               .ToListAsync();

            return new RawMaterialsInInventoryViewModel()
            {
                RawMaterials = rawMaterials,
                Inventories = await GetInventoriesAsync(),
                Colors = await colorService.GetAllColorsAsync(),
                Types = Enum.GetNames(typeof(RawMaterialType)).ToList()
            };
        }
    }
}
