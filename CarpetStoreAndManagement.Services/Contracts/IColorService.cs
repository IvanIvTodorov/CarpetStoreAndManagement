using CarpetStoreAndManagement.Data.Models;

namespace CarpetStoreAndManagement.Services.Contracts
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAllColorsAsync();
        Task<bool> CheckColorExistAsync(string colorName);
        Task AddColorAsync(string name);
    }
}
