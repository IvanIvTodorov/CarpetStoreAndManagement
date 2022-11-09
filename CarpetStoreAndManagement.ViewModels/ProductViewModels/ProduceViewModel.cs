using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class ProduceViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(3)] 
        public string InventoryName { get; set; }

        public IEnumerable<Inventory> Inventories { get; set; } = new List<Inventory>();

        public IEnumerable<Product> Products { get; set; } = new List<Product>();

    }
}
