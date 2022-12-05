using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace CarpetStoreAndManagement.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly CarpetStoreAndManagementDbContext context;
        private const int startQuantity = 1;
        private const int minProduct = 1;
        private const int maxProduct = 5;
        private readonly HtmlSanitizer sanitzer;

        public ProductService(CarpetStoreAndManagementDbContext context, HtmlSanitizer sanitzer)
        {
            this.context = context;
            this.sanitzer = sanitzer;
        }

        public async Task AddColorAsync(string name)
        {
            var sanitizedName = sanitzer.Sanitize(name);
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

        public async Task AddProductAsync(AddProductViewModel model)
        {
            var product = new Product()
            {
                ImgUrl = sanitzer.Sanitize(model.ImgUrl),
                Name = sanitzer.Sanitize(model.Name),
                Type = sanitzer.Sanitize(model.Type),
                Price = model.Price
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            var colors = new List<string>()
            {
                sanitzer.Sanitize(model.PrimaryColor),
                sanitzer.Sanitize(model.SecondaryColor)
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
               .Where(m => m.IsDeleted == false)
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

            var products = await context.Products
                .Where(x => x.Type == product.Type)
                .Take(maxProduct)
                .ToListAsync();

            return new ProductDetailsViewModel
            {
                Id = product.Id,
                ImgUrl = product.ImgUrl,
                Price = product.Price,
                Type = product.Type,
                Name = product.Name,
                Colors = product.ProductColors,
                Products = products
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

        public async Task<UserProduct> GetCurrentUserProduct(int productId)
        {
            var userProduct = await context.UserProducts
                .Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync();

            return userProduct;
        }

        public async Task<IEnumerable<Product>> GetProductsFromOrderAsync(int orderId)
        {
            var products = await context.ProductOrders
                 .Include(x => x.Product)
                 .Where(x => x.OrderId == orderId)
                 .ToListAsync();

            var orderedProducts = new List<Product>();

            foreach (var product in products)
            {
                orderedProducts.Add(product.Product);
            }

            return orderedProducts;
        }

        public async Task<EditProductViewModel> EditProductAsync(int productId)
        {
            var model = await context.Products
                .Include(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .Where(x => x.Id == productId)
                .Select(x => new EditProductViewModel
                {
                    Id = x.Id,
                    ImgUrl = x.ImgUrl,
                    Name = x.Name,
                    Price = x.Price,
                    PrimaryColor = x.ProductColors.FirstOrDefault(x => x.ProductId == productId).Color.Name,
                    SecondaryColor = x.ProductColors.ToList().Skip(1).FirstOrDefault().Color.Name,
                    Type = x.Type
                })
                .FirstOrDefaultAsync();
            return model;
        }

        public async Task EditProductAsync(EditProductViewModel model)
        {
            var product = await context.Products
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            product.ImgUrl = sanitzer.Sanitize(model.ImgUrl);
            product.Type = sanitzer.Sanitize(model.Type);
            product.Name = sanitzer.Sanitize(model.Name);
            product.Price = model.Price;

            await EditProductColorAsync(model.Id, sanitzer.Sanitize(model.PrimaryColor), sanitzer.Sanitize(model.SecondaryColor));

            await context.SaveChangesAsync();
        }

        public async Task EditProductColorAsync(int productId, string primaryColor, string secondaryColor)
        {
            var products = await context.ProductColors
                .Include(x => x.Color)
                .Where(x => x.ProductId == productId)
                .ToArrayAsync();

            if (products.Count() > minProduct && (secondaryColor == String.Empty || secondaryColor == null))
            {
                context.ProductColors.Remove(products[1]);
                await context.SaveChangesAsync();
            }

            if (products.Count() == minProduct && (secondaryColor != String.Empty || secondaryColor != null))
            {
                await AddColorAsync(secondaryColor);

                var color = await context.Colors
                    .Where(x => x.Name == secondaryColor)
                    .FirstOrDefaultAsync();

                context.ProductColors.Add(new ProductColor
                {
                    ProductId = productId,
                    ColorId = color.Id
                });

                await context.SaveChangesAsync();
            }

            if (products.Count() > minProduct && secondaryColor != String.Empty)
            {
                products[1].Color.Name = sanitzer.Sanitize(secondaryColor);
            }
            products[0].Color.Name = sanitzer.Sanitize(primaryColor);

            await context.SaveChangesAsync();
        }

        public async Task<bool> ProductIdExist(int productId)
        {
            var flag = await context.Products.AnyAsync(x => x.Id == productId);

            return flag;
        }
    }
}
