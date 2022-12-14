using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.ViewModels.OrderViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IOrderService
    {
        Task MakeOrderAsync(string userId);

        Task<IEnumerable<OrdersViewModel>> GetAllOrdersAsync();
        Task<IEnumerable<MyOrdersViewModel>> GetMyOrdersAsync(string userId);

        Task<IEnumerable<Product>> CompleteOrderAsync(int orderId);

        Task<ProduceFromOrderViewModel> SetProduceFromOrderViewModelAsync(int orderid);

        Task<bool> CheckIfOrderExistAsync(int orderId);
    }
}
