using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models.Inventory
{
    public class InventoryProduct
    {
        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; } = null!;

        public int ProductId { get; set; }

        public Product.Product Product { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }

    }
}
