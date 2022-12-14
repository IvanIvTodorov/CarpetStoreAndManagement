using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models.Inventory
{
    public class InventoryRawMaterial
    {
        public int RawMaterialId { get; set; }

        public RawMaterial RawMaterial { get; set; } = null!;

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }

    }
}
