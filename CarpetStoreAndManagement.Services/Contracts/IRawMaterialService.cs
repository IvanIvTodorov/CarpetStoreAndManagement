using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.ViewModels.InventoryViewModels;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;


namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IRawMaterialService
    {

        Task AddRawMaterialAsync(AddRawMaterialViewModel model, RawMaterialType type);

        Task AddToInventoryAsync(int id, string name, int qty);

        Task<IEnumerable<InventoryRawMaterial>> GetRawMatInInventoryBySearchAsync(RawMaterialsInInventoryViewModel model);

    }
}
