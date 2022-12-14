using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models.Inventory
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; } = null!;

        public ICollection<InventoryProduct> InventoryProducts { get; set; } = new List<InventoryProduct>();

        public ICollection<InventoryRawMaterial> InventoryRawMaterials { get; set; } = new List<InventoryRawMaterial>();
    }
}
