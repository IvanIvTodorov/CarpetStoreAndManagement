using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Services
{
    public class RawMaterialService : IRawMaterialService
    {
        private readonly CarpetStoreAndManagementDbContext context;

        public RawMaterialService(CarpetStoreAndManagementDbContext context)
        {
            this.context = context;
        }

        public async Task AddColorAsync(string name)
        {
            if (!context.Colors.Any(x => x.Name == name))
            {
                var color = new Color()
                {
                    Name = name
                };

                await context.Colors.AddAsync(color);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddRawMaterialAsync(AddRawMaterialViewModel model, string type)
        {
            await AddColorAsync(model.Color);

            var color = await context.Colors
            .Where(x => x.Name == model.Color)
            .FirstOrDefaultAsync();

            var material = new RawMaterial()
            {
                Type = type,
                ColorId = color.Id
            };

            await context.RawMaterials.AddAsync(material);
            await context.SaveChangesAsync();

            await AddToInventoryAsync(material.Id, model.InventoryName, model.Quantity);
        }

        public async Task AddToInventoryAsync(int id, string name, int qty)
        {
            var inventory = await context.Inventories
               .Where(x => x.Name == name)
               .FirstOrDefaultAsync();

            var inventoryRawMaterial = new InventoryRawMaterial()
            {
                InventoryId = inventory.Id,
                RawMaterialId = id,
                Quantity = qty
            };

            await context.InventoryRawMaterials.AddAsync(inventoryRawMaterial);
            await context.SaveChangesAsync();
        }
    }
}
