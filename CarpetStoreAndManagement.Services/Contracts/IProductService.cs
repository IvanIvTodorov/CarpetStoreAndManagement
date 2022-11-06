using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.ViewModels.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ShowAllProductsViewModel>> GetAllProductsAsync();

        Task AddProductAsync(AddProductViewModel model);

        Task<IEnumerable<Inventory>> GetInventoriesAsync();

        Task<ProductDetailsViewModel> ProductDetailsAsync(int productId);

        Task AddColorAsync(string name);

        Task RemoveProductAsync(int productId);

        Task AddProductToCartAsync(int productId, string userId);

        Task<IEnumerable<ProductsInCartViewModel>> GetAllProductsInCartAsync(string userId);

    }
}
