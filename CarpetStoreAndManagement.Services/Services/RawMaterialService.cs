﻿using CarpetStoreAndManagement.Data;
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
            if (!context.RawMaterials.Any(x => x.Type == type && x.Color.Name == model.Color))
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

            var rawMaterial = await context.RawMaterials
                .Include(x => x.Color)
                .Where(x => x.Type == type && x.Color.Name == model.Color)
                .FirstOrDefaultAsync();

            await AddToInventoryAsync(rawMaterial.Id, model.InventoryName, model.Quantity);
        }

        public async Task AddToInventoryAsync(int id, string name, int qty)
        {
            if (!context.InventoryRawMaterials.Any(x => x.Inventory.Name == name && x.RawMaterialId == id))
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
    }
}
