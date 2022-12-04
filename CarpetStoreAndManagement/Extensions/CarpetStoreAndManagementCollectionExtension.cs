using CarpetStoreAndManagement.Services.Contracts;
using CarpetStoreAndManagement.Services.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CarpetStoreAndManagementCollectionExtension
    {

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IRawMaterialService, RawMaterialService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            return services;
        }
    }
}
