using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.Services.Contracts;
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

        public OrderService(CarpetStoreAndManagementDbContext context)
        {
            this.context = context;
        }

        public async Task MakeOrderAsync(string userId)
        {
            var order = new Order();

            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            var productOrder = new List<ProductOrder>();
            var userProduct = new List<UserProduct>();

            var productIds = await context.UserProducts
                .Where(x => x.UserId == userId)
                .Select(x => x.ProductId)
                .ToListAsync();
            
            foreach (var id in productIds)
            {
                var prodOrder = new ProductOrder()
                {
                    OrderId = order.Id,
                    ProductId = id,
                };

                productOrder.Add(prodOrder);

                var userProd = await context.UserProducts.Where(x => x.UserId == userId && x.ProductId == id).FirstOrDefaultAsync();

                userProduct.Add(userProd);
            }

            await context.ProductOrders.AddRangeAsync(productOrder);

            var userOrder = new UserOrder()
            {
                UserId = userId,
                OrderId = order.Id
            };

            await context.UserOrders.AddAsync(userOrder);

            context.UserProducts.RemoveRange(userProduct);

            await context.SaveChangesAsync();
        }
    }
}
