using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.ViewModels.RawMaterialViewModels;


namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IRawMaterialService
    {

        Task AddRawMaterialAsync(AddRawMaterialViewModel model, RawMaterialType type);

        Task AddToInventoryAsync(int id, string name, int qty);

    }
}
