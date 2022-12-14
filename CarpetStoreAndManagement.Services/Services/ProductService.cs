using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Ganss.Xss;
using Microsoft.EntityFrameworkCore;

namespace CarpetStoreAndManagement.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly CarpetStoreAndManagementDbContext context;
        private readonly IColorService colorService;
        private const int startQuantity = 1;
        private const int minProduct = 1;
        private const int maxProduct = 5;
        private readonly HtmlSanitizer sanitizer;

        public ProductService(CarpetStoreAndManagementDbContext context, HtmlSanitizer sanitizer, IColorService colorService)
        {
            this.context = context;
            this.sanitizer = sanitizer;
            this.colorService = colorService;
        }



        public async Task AddProductAsync(AddProductViewModel model)
        {
            var product = new Product()
            {
                ImgUrl = sanitizer.Sanitize(model.ImgUrl),
                Name = sanitizer.Sanitize(model.Name),
                Type = sanitizer.Sanitize(model.Type),
                Price = model.Price
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();


            var primary = sanitizer.Sanitize(model.PrimaryColor);
            var secondary = sanitizer.Sanitize(model.SecondaryColor);

            if (primary != null && primary != String.Empty)
            {
                await colorService.AddColorAsync(primary);

                var color = await context.Colors
                    .Where(x => x.Name == primary)
                    .FirstOrDefaultAsync();

                var productColors = new ProductColor()
                {
                    ColorId = color.Id,
                    ProductId = product.Id,
                    ColorType = ProductColorType.PrimaryColor
                };
                await context.ProductColors.AddAsync(productColors);
            }

            if (secondary != null && secondary != String.Empty)
            {
                await colorService.AddColorAsync(secondary);

                var color = await context.Colors
                    .Where(x => x.Name == secondary)
                    .FirstOrDefaultAsync();

                var productColors = new ProductColor()
                {
                    ColorId = color.Id,
                    ProductId = product.Id,
                    ColorType = ProductColorType.SecondaryColor
                };
                await context.ProductColors.AddAsync(productColors);
            }

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

        public async Task<List<string>> GetProductColorsAsync(int productId)
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

        public async Task ProduceProductAsync(ProduceViewModel model, int productId)
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
                .Where(x => x.Type == product.Type && x.Id != product.Id)
                .Take(maxProduct)
                .ToListAsync();

            var primary = product.ProductColors.Where(x => x.ColorType == ProductColorType.PrimaryColor).FirstOrDefault();
            var secondary = product.ProductColors.Where(x => x.ColorType == ProductColorType.SecondaryColor).FirstOrDefault();

            return new ProductDetailsViewModel
            {
                Id = product.Id,
                ImgUrl = product.ImgUrl,
                Price = product.Price,
                Type = product.Type,
                Name = product.Name,
                PrimaryColor = primary.Color.Name,
                SecondaryColor = secondary != null ? secondary.Color.Name : null,
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

        public async Task<UserProduct> GetCurrentUserProductAsync(int productId)
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
                    PrimaryColor = x.ProductColors.Where(x => x.ColorType == ProductColorType.PrimaryColor).FirstOrDefault().Color.Name,
                    SecondaryColor = x.ProductColors.Where(x => x.ColorType == ProductColorType.SecondaryColor).FirstOrDefault().Color.Name,
                    Type = x.Type
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<int> EditProductAsync(EditProductViewModel model)
        {
            var product = await context.Products
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();

            product.ImgUrl = sanitizer.Sanitize(model.ImgUrl);
            product.Type = sanitizer.Sanitize(model.Type);
            product.Name = sanitizer.Sanitize(model.Name);
            product.Price = model.Price;


            await EditProductColorAsync(sanitizer.Sanitize(model.PrimaryColor), sanitizer.Sanitize(model.SecondaryColor), model.Id);

            await context.SaveChangesAsync();

            return model.Id;
        }

        public async Task EditProductColorAsync(string primaryColor, string secondaryColor, int modelId)
        {
            await colorService.AddColorAsync(secondaryColor);
            await colorService.AddColorAsync(primaryColor);

            var primary = await context.ProductColors
               .Include(x => x.Color)
               .Where(x => x.ProductId == modelId)
               .Where(x => x.ColorType == ProductColorType.PrimaryColor)
               .FirstOrDefaultAsync();

            context.ProductColors.Remove(primary);
            await context.SaveChangesAsync();

            var color = await context.Colors
                .Where(x => x.Name == primaryColor)
                .FirstOrDefaultAsync();

            var productColor = new ProductColor()
            {
                ProductId = modelId,
                ColorId = color.Id

            };

            await context.ProductColors.AddAsync(productColor);

            var secondary = await context.ProductColors
                .Include(x => x.Color)
                .Where(x => x.ProductId == modelId && x.ColorType == ProductColorType.SecondaryColor)
                .FirstOrDefaultAsync();

            var color2 = await context.Colors
                   .Where(x => x.Name == secondaryColor)
                   .FirstOrDefaultAsync();

            if (secondary == null && (secondaryColor != String.Empty))
            {

                context.ProductColors.Add(new ProductColor
                {
                    ProductId = modelId,
                    ColorId = color2.Id,
                    ColorType = ProductColorType.SecondaryColor
                });

                await context.SaveChangesAsync();
            }

            if (secondary != null && secondaryColor != String.Empty)
            {
                context.ProductColors.Remove(secondary);
                await context.SaveChangesAsync();

                var productColor2 = new ProductColor()
                {
                    ProductId = modelId,
                    ColorId = color2.Id

                };

                await context.ProductColors.AddAsync(productColor2);
            }


            if (secondary != null && (secondaryColor == String.Empty || secondaryColor == null))
            {
                context.ProductColors.Remove(secondary);
            }

            await context.SaveChangesAsync();
        }

        public async Task<bool> ProductIdExistAsync(int productId)
        {
            var flag = await context.Products.AnyAsync(x => x.Id == productId);

            return flag;
        }

        public async Task<IEnumerable<ShowAllProductsViewModel>> GetProductsByTypeAsync(string type)
        {
            var sanitizedType = sanitizer.Sanitize(type);
            var enteties = await context.Products
               .Include(m => m.InventoryProducts)
               .Where(m => m.IsDeleted == false && m.Type == sanitizedType)
               .ToListAsync();

            return enteties
                .Select(m => new ShowAllProductsViewModel()
                {
                    Id = m.Id,
                    ImgUrl = m.ImgUrl,
                    Name = m.Name,
                    Type = m.Type,
                    Price = m.Price
                });
        }

        public async Task<bool> CheckIfTypeExistAsync(string type)
        {
            var sanitizedType = sanitizer.Sanitize(type);
            return await context.Products.AnyAsync(x => x.Type == sanitizedType);
        }

        public async Task<List<string>> GetAllProductTypesAsync()
        {
            var types = await context.Products
                .Select(x => x.Type)
                .Distinct()
                .ToListAsync();

            return types;
        }

        public async Task<IEnumerable<InventoryProduct>> GetProductsInInventoryBySearchAsync(ProductsInInventoryViewModel model)
        {
            var productsId = await context.InventoryProducts
                .Include(x => x.Inventory)
                .Include(x => x.Product)
                .Where(x => x.Inventory.Name == model.InventoryName
                && x.Product.Type == model.Type)
                .Select(x => x.ProductId)
                .ToListAsync();

            var prodColor = await context.ProductColors
                .Include(x => x.Color)
                .Where(x => x.Color.Name == model.Color)
                .Select(x => x.ProductId)
                .ToListAsync();

            var matched = productsId.Intersect(prodColor);

            var products = await context.InventoryProducts
                .Include(x => x.Product)
                .ThenInclude(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .Where(x => matched.Contains(x.ProductId))
                .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> PorductsByTypeAsync(string type)
        {
            var sanitizedType = sanitizer.Sanitize(type);
            var productTypes = await context.Products
               .Where(m => m.Type == sanitizedType)
               .ToListAsync();

            return productTypes;
        }
    }
}
