using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.RawMaterialViewModels
{
    public class AddRawMaterialViewModel
    {
        [Required]
        public string Color { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public string InventoryName { get; set; } = null!;

        public IEnumerable<Inventory> Inventories { get; set; } = new List<Inventory>();
        public IEnumerable<Color> Colors { get; set; } = new List<Color>();
    }
}
