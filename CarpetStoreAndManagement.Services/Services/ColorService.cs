using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Services.Contracts;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace CarpetStoreAndManagement.Services.Services
{
    public class ColorService : IColorService
    {
        private readonly CarpetStoreAndManagementDbContext context;
        private readonly HtmlSanitizer sanitizer;

        public ColorService(CarpetStoreAndManagementDbContext context, HtmlSanitizer sanitizer)
        {
            this.context = context;
            this.sanitizer = sanitizer;
        }

        public Task<bool> CheckColorExistAsync(string colorName)
        {
            return context.Colors.AnyAsync(x => x.Name == colorName);
        }

        public async Task<IEnumerable<Color>> GetAllColorsAsync()
        {
            return await context.Colors.ToListAsync();
        }

        public async Task AddColorAsync(string name)
        {
            var sanitizedName = sanitizer.Sanitize(name);
            if (!context.Colors.Any(x => x.Name == sanitizedName))
            {
                var color = new Color()
                {
                    Name = sanitizedName
                };

                await context.Colors.AddAsync(color);
                await context.SaveChangesAsync();
            }
        }
    }
}
