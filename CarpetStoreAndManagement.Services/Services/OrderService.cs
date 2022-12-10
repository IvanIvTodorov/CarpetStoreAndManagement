using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.ViewModels.OrderViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly CarpetStoreAndManagementDbContext context;
        private readonly IProductService productService;
        private readonly IInventoryService inventoryService;
        public OrderService(CarpetStoreAndManagementDbContext context, IProductService productService, IInventoryService inventoryService)
        {
            this.context = context;
            this.productService = productService;
            this.inventoryService = inventoryService;
        }

        public async Task<bool> CheckIfOrderExist(int orderId)
        {
            return await context.Orders.AnyAsync(x => x.Id == orderId);

        }

        public async Task<IEnumerable<Product>> CompleteOrderAsync(int orderId)
        {
            var missingProducts = new List<Product>();

            var products = await context.ProductOrders
                .Where(x => x.OrderId == orderId)
                .ToListAsync();

            foreach (var product in products)
            {
                var curentProd = await context.InventoryProducts
                    .Include(x => x.Product)
                    .Where(x => x.ProductId == product.ProductId)
                    .FirstOrDefaultAsync();

                if (curentProd == null || curentProd.Quantity < product.Quantity)
                {
                    var productDb = await context.Products.Where(x => x.Id == product.ProductId).FirstOrDefaultAsync();
                    missingProducts.Add(productDb);
                }
            }

            if (missingProducts.Count == 0)
            {
                var order = await context.UserOrders
                    .Where(x => x.OrderId == orderId)
                    .FirstOrDefaultAsync();

                order.IsCompleted = true;

                foreach (var product in products)
                {
                    var inventoryProduct = context.InventoryProducts
                        .Where(x => x.ProductId == product.ProductId)
                        .FirstOrDefault();

                    inventoryProduct.Quantity -= product.Quantity;
                }

                await context.SaveChangesAsync();
            }
            return missingProducts;
        }

        public async Task<IEnumerable<OrdersViewModel>> GetAllOrdersAsync()
        {
            var orders = await context.UserOrders
                .Include(x => x.Order)
                .ThenInclude(x => x.ProductOrders)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .Include(x => x.User)
                .Where(x => x.IsCompleted == false)
                .ToListAsync();

            var ordersViewModel = new List<OrdersViewModel>();


            foreach (var order in orders)
            {
                var productName = new List<string>();
                var productType = new List<string>();
                var productColors = new List<string>();
                var productQty = new List<int>();

                foreach (var product in order.Order.ProductOrders)
                {
                    productName.Add(product.Product.Name);
                    productType.Add(product.Product.Type);
                    productQty.Add(product.Quantity);

                    var colors = new List<string>();
                    foreach (var color in product.Product.ProductColors)
                    {
                        colors.Add(color.Color.Name);
                    }

                    productColors.Add(String.Join(" ", colors));
                }

                var curentOrder = new OrdersViewModel()
                {
                    OrderId = order.OrderId,
                    ClientName = order.User.UserName,
                    ProductName = productName,
                    ProductType = productType,
                    ProductColors = productColors,
                    ProductQuantity = productQty,
                    TotalPrice = order.Order.TotalPrice
                };

                ordersViewModel.Add(curentOrder);
            }

            return ordersViewModel;
        }

        public async Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync(string userId)
        {
            var orders = await context.UserOrders
                .Include(x => x.Order)
                .ThenInclude(x => x.ProductOrders)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductColors)
                .ThenInclude(x => x.Color)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var ordersViewModel = new List<MyOrdersViewModel>();


            foreach (var order in orders)
            {
                var productName = new List<string>();
                var productType = new List<string>();
                var productColors = new List<string>();
                var productQty = new List<int>();

                foreach (var product in order.Order.ProductOrders)
                {
                    productName.Add(product.Product.Name);
                    productType.Add(product.Product.Type);
                    productQty.Add(product.Quantity);

                    var colors = new List<string>();
                    foreach (var color in product.Product.ProductColors)
                    {
                        colors.Add(color.Color.Name);
                    }

                    productColors.Add(String.Join(", ", colors));
                }

                var curentOrder = new MyOrdersViewModel()
                {
                    OrderId = order.OrderId,
                    ProductName = productName,
                    ProductType = productType,
                    ProductColors = productColors,
                    ProductQuantity = productQty,
                    TotalPrice = order.Order.TotalPrice,
                    IsCompleted = order.IsCompleted

                };

                ordersViewModel.Add(curentOrder);
            }

            return ordersViewModel;
        }

        public async Task MakeOrderAsync(string userId)
        {
            var products = await context.UserProducts
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var order = new Order();
            order.TotalPrice = products.Sum(x => x.Product.Price * x.Quantity);

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            var productOrder = new List<ProductOrder>();
            var userProduct = new List<UserProduct>();

            foreach (var product in products)
            {
                var prodOrder = new ProductOrder()
                {
                    OrderId = order.Id,
                    ProductId = product.ProductId,
                    Quantity = product.Quantity
                };

                productOrder.Add(prodOrder);

                var userProd = await context.UserProducts
                    .Where(x => x.UserId == userId && x.ProductId == product.ProductId)
                    .FirstOrDefaultAsync();

                userProduct.Add(userProd);
            }

            await context.ProductOrders.AddRangeAsync(productOrder);
            context.UserProducts.RemoveRange(userProduct);

            var userOrder = new UserOrder()
            {
                UserId = userId,
                OrderId = order.Id
            };

            await context.UserOrders.AddAsync(userOrder);

            await context.SaveChangesAsync();
        }

        public async Task<ProduceFromOrderViewModel> SetProduceFromOrderViewModelAsync(int orderid)
        {
            var model = new ProduceFromOrderViewModel()
            {
                Inventories = await inventoryService.GetInventoriesAsync(),
                OrderId = orderid,
                Products = await productService.GetProductsFromOrderAsync(orderid)
            };

            return model;
        }
    }
}
