using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;

namespace CarpetStoreAndManagement.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly CarpetStoreAndManagementDbContext context;

        public ProductService(CarpetStoreAndManagementDbContext context)
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

        public async Task AddProductAsync(AddProductViewModel model)
        {
            var product = new Product()
            {
                ImgUrl = model.ImgUrl,
                Name = model.Name,
                Type = model.Type,
                Price = model.Price,
                Quantity = model.Quantity
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            var colors = new List<string>()
            {
                model.PrimaryColor,
                model.SecondaryColor
            };

            foreach (var name in colors)
            {
                await AddColorAsync(name);

                var color = await context.Colors
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync();

                var productColors = new ProductColor()
                {
                    ColorId = color.Id,
                    ProductId = product.Id
                };
                await context.ProductColors.AddAsync(productColors);
            };

            await context.SaveChangesAsync();
        }

        public async Task AddProductToCartAsync(int productId, string userId)
        {

            if (context.UserProducts.Any(x => x.UserId == userId && x.ProductId == productId))
            {
                var userProd = await context.UserProducts
                    .Where(x => x.UserId == userId && x.ProductId == productId)
                    .FirstOrDefaultAsync();

                userProd.Quantity += 1;

            }
            else
            {
                var userProduct = new UserProduct()
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1,

                };

                await context.UserProducts.AddAsync(userProduct);
            }
            await context.SaveChangesAsync();
        }

        public async Task DecreaseProductQtyAsync(int productId)
        {
            var userProd = await context.UserProducts
                     .Where(x =>x.ProductId == productId)
                     .FirstOrDefaultAsync();

            userProd.Quantity -= 1;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShowAllProductsViewModel>> GetAllProductsAsync()
        {
            var enteties = await context.Products
               .Where(m => m.IsDeleted == false)
               .Include(m => m.InventoryProducts)
               .ToListAsync();

            return enteties
                .Select(m => new ShowAllProductsViewModel()
                {
                    Id = m.Id,
                    ImgUrl = m.ImgUrl,
                    Name = m.Name,
                    Price = m.Price
                });
        }

        public async Task<IEnumerable<ProductsInCartViewModel>> GetAllProductsInCartAsync(string userId)
        {
            var products = await context.UserProducts
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return products
                .Select(x => new ProductsInCartViewModel()
                {
                    Id = x.Product.Id,
                    Name = x.Product.Name,
                    Price = x.Product.Price,
                    Quantity = x.Quantity,
                    ImgUrl = x.Product.ImgUrl,
                    TotalPrice = x.Product.Price * x.Quantity
                });
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
        {
            return await context.Inventories.ToListAsync();
        }

        public async Task IncreaseProductQtyAsync(int productId)
        {
            var userProd = await context.UserProducts
                     .Where(x => x.ProductId == productId)
                     .FirstOrDefaultAsync();

            userProd.Quantity += 1;

            await context.SaveChangesAsync();
        }

        public async Task<ProductDetailsViewModel> ProductDetailsAsync(int productId)
        {
            var product = await context.Products
                .Include(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync();

            return new ProductDetailsViewModel
            {
                Id = product.Id,
                ImgUrl = product.ImgUrl,
                Price = product.Price,
                Type = product.Type,
                Name = product.Name,
                Colors = product.ProductColors
            };
        }

        public async Task RemoveFromCartAsync(int productId, string userId)
        {
            var userProd = await context.UserProducts
                    .Where(x => x.UserId == userId && x.ProductId == productId)
                    .FirstOrDefaultAsync();

            context.UserProducts.Remove(userProd);
            await context.SaveChangesAsync();
        }

        public async Task RemoveProductAsync(int productId)
        {
            var product = await context.Products
                .Where(x => x.Id == productId)
                .FirstOrDefaultAsync();

            product.IsDeleted = true;

            await context.SaveChangesAsync();
        }
    }
}
