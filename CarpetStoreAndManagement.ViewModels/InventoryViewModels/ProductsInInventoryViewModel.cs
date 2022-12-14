using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.InventoryViewModels
{
    public class ProductsInInventoryViewModel
    {
        [MinLength(3)]
        [MaxLength(25)]
        public string InventoryName { get; set; } = null!;
        [MinLength(1)]
        [MaxLength(20)]
        public string Color { get; set; }
        [MinLength(3)]
        [MaxLength(10)]
        public string Type { get; set; }

        public IEnumerable<InventoryProduct> Products { get; set; } = new List<InventoryProduct>();
        public IEnumerable<Inventory> Inventories { get; set; } = new List<Inventory>();
        public IEnumerable<Color> Colors { get; set; } = new List<Color>();
        public IEnumerable<string> Types { get; set; } = new List<string>();

    }
}
