using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Services.Contracts;
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

        public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
        {
            return await context.Inventories.ToListAsync();
        }
    }
}
