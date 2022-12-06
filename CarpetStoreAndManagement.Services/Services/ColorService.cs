using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Services
{
    public class ColorService : IColorService
    {
        private readonly CarpetStoreAndManagementDbContext context;

        public ColorService(CarpetStoreAndManagementDbContext context)
        {
            this.context = context;
        }

        public Task<bool> CheckColorExistAsync(string colorName)
        {
            return context.Colors.AnyAsync(x => x.Name == colorName);
        }

        public async Task<IEnumerable<Color>> GetAllColorsAsync()
        {
            return await context.Colors.ToListAsync();
        }
    }
}
