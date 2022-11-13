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
        private const int startQuantity = 1;

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
                Price = model.Price
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
                if (name != null)
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

                userProd.Quantity++;
            }
            else
            {
                var userProduct = new UserProduct()
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = startQuantity,
                };

                await context.UserProducts.AddAsync(userProduct);
            }
            await context.SaveChangesAsync();
        }

        public async Task DecreaseProductQtyInCartAsync(int productId)
        {
            var userProd = await context.UserProducts
                     .Where(x => x.ProductId == productId)
                     .FirstOrDefaultAsync();

            userProd.Quantity--;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShowAllProductsViewModel>> GetAllProductsAsync()
        {
            var enteties = await context.Products
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

        public async Task<List<string>> GetProductColors(int productId)
        {
            return await context.ProductColors
                .Include(x => x.Color)
                .Where(x => x.ProductId == productId)
                .Select(x => x.Color.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task IncreaseProductQtyInCartAsync(int productId)
        {
            var userProd = await context.UserProducts
                     .Where(x => x.ProductId == productId)
                     .FirstOrDefaultAsync();

            userProd.Quantity++;

            await context.SaveChangesAsync();
        }

        public async Task ProduceProduct(ProduceViewModel model, int productId)
        {
            
            if (await context.InventoryProducts
                .Include(x => x.Inventory)
                .AnyAsync(x => x.Inventory.Name == model.InventoryName && x.ProductId == productId))
            {
                var invent = await context.InventoryProducts
                .Include(x => x.Inventory)
                .Where(x => x.Inventory.Name == model.InventoryName && x.ProductId == productId)
                .FirstOrDefaultAsync();

                invent.Quantity += model.Quantity;
            }
            else
            {
                var inventory = await context.Inventories
                 .Where(x => x.Name == model.InventoryName)
                 .FirstOrDefaultAsync();

                var inventoryProd = new InventoryProduct()
                {
                    InventoryId = inventory.Id,
                    ProductId = productId,
                    Quantity = model.Quantity,
                };

                await context.InventoryProducts.AddAsync(inventoryProd);
            }

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

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<UserProduct> GetCurrentUserProduct(int productId)
        {
            var userProduct = await context.UserProducts
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();

            return userProduct;
        }
    }
}
