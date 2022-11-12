using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using Microsoft.EntityFrameworkCore;


namespace CarpetStoreAndManagement.Services.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly CarpetStoreAndManagementDbContext context;

        public InventoryService(CarpetStoreAndManagementDbContext context)
        {
            this.context = context;
        }

        public async Task AddInventoryAsync(string name)
        {
            if (!context.Inventories.Any(x => x.Name == name))
            {
                var invent = new Inventory()
                {
                    Name = name
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
            return await context.Inventories.ToListAsync();
        }

        public async Task<bool> CheckRawMaterialsForProduce(List<string> colors, int qty, string inventoryName)
        {
            var flag = true;
            foreach (var color in colors)
            {
                var rawMaterial = await context.InventoryRawMaterials
                    .Include(x => x.Inventory)
                    .Include(x => x.RawMaterial)
                    .ThenInclude(x => x.Color)
                    .Where(x => x.RawMaterial.Color.Name == color && x.Inventory.Name == inventoryName)
                    .FirstOrDefaultAsync();

                if (rawMaterial == null || rawMaterial.Quantity < qty )
                {
                    flag = false;
                }
            }
            return flag;
        }
    }
}
