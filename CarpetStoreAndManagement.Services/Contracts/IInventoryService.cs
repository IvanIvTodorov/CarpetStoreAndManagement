﻿using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IInventoryService
    {

        Task AddInventoryAsync(string name);

        Task<IEnumerable<Inventory>> GetInventoriesAsync();
        Task<bool> CheckIfInventoryNameExistAsync(string name);

        Task<AllInventoryViewModel> GetAllItemsAsync();
        Task<ProductsInInventoryViewModel> GetInventoryProductAsync();
        Task<RawMaterialsInInventoryViewModel> GetInventoryRawMaterialAsync();

        Task<bool> CheckRawMaterialsForProduceAsync(List<string> colors, int qty, string inventoryName);

        Task DecreaseUsedRawMaterialsInInventoryAsync(List<string> colors, int qty, string inventoryName);

    }
}
