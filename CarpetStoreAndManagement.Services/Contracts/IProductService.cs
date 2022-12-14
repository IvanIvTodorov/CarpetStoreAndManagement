using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ShowAllProductsViewModel>> GetAllProductsAsync();
        Task<IEnumerable<ShowAllProductsViewModel>> GetProductsByTypeAsync(string type);

        Task<bool> CheckIfTypeExistAsync(string type);
        Task<List<string>> GetAllProductTypesAsync();

        Task AddProductAsync(AddProductViewModel model);
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<ProductDetailsViewModel> ProductDetailsAsync(int productId);

        Task RemoveProductAsync(int productId);
        Task<EditProductViewModel> EditProductAsync(int productId);
        Task<int> EditProductAsync(EditProductViewModel model);
        Task EditProductColorAsync(string primaryColor, string secondaryColor, int productId);

        Task AddProductToCartAsync(int productId, string userId);

        Task<IEnumerable<ProductsInCartViewModel>> GetAllProductsInCartAsync(string userId);

        Task DecreaseProductQtyInCartAsync(int productId);
        Task IncreaseProductQtyInCartAsync(int productId);
        Task RemoveFromCartAsync(int productId, string userId);

        Task ProduceProductAsync(ProduceViewModel model, int productId);

        Task<List<string>> GetProductColorsAsync(int productId);

        Task<UserProduct> GetCurrentUserProductAsync(int productId);

        Task<IEnumerable<Product>> GetProductsFromOrderAsync(int orderId);

        Task<bool> ProductIdExistAsync(int productId);

        Task<IEnumerable<InventoryProduct>> GetProductsInInventoryBySearchAsync(ProductsInInventoryViewModel model);
        Task<IEnumerable<Product>> PorductsByTypeAsync(string type);

    }
}
