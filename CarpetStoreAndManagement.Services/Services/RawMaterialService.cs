using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
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

        public async Task AddProductAsync(AddRawMaterialViewModel model, string type)
        {
            await AddColorAsync(model.Color);

            var color = await context.Colors
            .Where(x => x.Name == model.Color)
            .FirstOrDefaultAsync();

            var material = new RawMaterial()
            {
                Type = type,
                ColorId = color.Id,
                Quantity = model.Quantity
            };

            await context.RawMaterials.AddAsync(material);
            await context.SaveChangesAsync();

            await context.SaveChangesAsync();
        }
    }
}
