﻿using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IInventoryService
    {

        Task AddInventoryAsync(string name);

        Task<IEnumerable<Inventory>> GetInventoriesAsync();

        Task<AllInventoryViewModel> GetAllItemsAsync();

        Task<bool> CheckRawMaterialsForProduce(List<string> colors, int qty, string inventoryName);

    }
}
