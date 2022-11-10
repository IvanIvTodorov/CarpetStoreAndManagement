using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.InventoryViewModels
{
    public class AllInventoryViewModel
    {
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string InventoryName { get; set; }

        public IEnumerable<InventoryProduct> Products { get; set; } = new List<InventoryProduct>();

        public IEnumerable<InventoryRawMaterial> RawMaterials { get; set; } = new List<InventoryRawMaterial>();
    }
}
