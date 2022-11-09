using CarpetStoreAndManagement.Data.Models.Inventory;
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
    }
}
