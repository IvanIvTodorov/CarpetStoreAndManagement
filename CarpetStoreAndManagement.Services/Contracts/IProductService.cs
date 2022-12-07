﻿using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
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
        Task<IEnumerable<ShowAllProductsViewModel>> GetProductsByTypeAsync(string type);

        Task<bool> CheckIfTypeExistAsync(string type);
        Task<List<string>> GetAllProductTypesAsync();

        Task AddProductAsync(AddProductViewModel model);
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<ProductDetailsViewModel> ProductDetailsAsync(int productId);

        Task AddColorAsync(string name);

        Task RemoveProductAsync(int productId);
        Task<EditProductViewModel> EditProductAsync(int productId);
        Task EditProductAsync(EditProductViewModel model);
        Task EditProductColorAsync(int productId,string primaryColor, string secondaryColor);

        Task AddProductToCartAsync(int productId, string userId);

        Task<IEnumerable<ProductsInCartViewModel>> GetAllProductsInCartAsync(string userId);

        Task DecreaseProductQtyInCartAsync(int productId);
        Task IncreaseProductQtyInCartAsync(int productId);
        Task RemoveFromCartAsync(int productId, string userId);

        Task ProduceProduct(ProduceViewModel model, int productId);

        Task<List<string>> GetProductColors(int productId);

        Task<UserProduct> GetCurrentUserProduct(int productId);

        Task<IEnumerable<Product>> GetProductsFromOrderAsync(int orderId);

        Task<bool> ProductIdExist(int productId);

        Task<IEnumerable<InventoryProduct>> GetProductsInInventoryBySearch(ProductsInInventoryViewModel model);

    }
}
