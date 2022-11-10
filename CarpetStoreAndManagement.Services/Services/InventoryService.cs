using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
