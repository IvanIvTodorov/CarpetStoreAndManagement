using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;
using Ganss.Xss;
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
        private readonly HtmlSanitizer sanitizer;

        public RawMaterialService(CarpetStoreAndManagementDbContext context, HtmlSanitizer sanitizer)
        {
            this.context = context;
            this.sanitizer = sanitizer;  
        }

        public async Task AddRawMaterialAsync(AddRawMaterialViewModel model, RawMaterialType type)
        {
            if (!await context.RawMaterials.AnyAsync(x => x.Type == type && x.Color.Name == model.Color))
            {
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
            else
            {
                var rawMaterial = await context.RawMaterials
               .Include(x => x.Color)
               .Where(x => x.Type == type && x.Color.Name == model.Color)
               .FirstOrDefaultAsync();

                await AddToInventoryAsync(rawMaterial.Id, sanitizer.Sanitize(model.InventoryName), model.Quantity);
            }       
        }

        public async Task AddToInventoryAsync(int id, string name, int qty)
        {
            if (!await context.InventoryRawMaterials.AnyAsync(x => x.Inventory.Name == name && x.RawMaterialId == id))
            {
                var inventory = await context.Inventories
                  .Where(x => x.Name == name)
                  .FirstOrDefaultAsync();

                var rawMaterial = await context.RawMaterials
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();


                var inventoryRawMaterial = new InventoryRawMaterial()
                {
                    InventoryId = inventory.Id,
                    RawMaterialId = id,
                    Quantity = qty
                };

                await context.InventoryRawMaterials.AddAsync(inventoryRawMaterial);
            }
            else
            {
                var inventory = await context.InventoryRawMaterials
                    .Where(x => x.Inventory.Name == name && x.RawMaterialId == id)
                    .FirstOrDefaultAsync();

                inventory.Quantity += qty;
            }
           
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InventoryRawMaterial>> GetRawMatInInventoryBySearchAsync(RawMaterialsInInventoryViewModel model)
        {
            var rawMatId = await context.InventoryRawMaterials
                 .Include(x => x.Inventory)
                 .Include(x => x.RawMaterial)
                 .Where(x => x.Inventory.Name == model.InventoryName)
                 .Select(x => x.RawMaterialId)
                 .ToListAsync();

            var rawMatColor = await context.RawMaterials
                .Where(x => x.Color.Name == model.Color)
                .Select(x => x.Id)
                .ToListAsync();

            var matched = rawMatId.Intersect(rawMatColor);

            var products = await context.InventoryRawMaterials
                .Include(x => x.RawMaterial)
                .ThenInclude(x => x.Color)
                .Where(x => matched.Contains(x.RawMaterialId))
                .ToListAsync();

            return products;
        }
    }
}
