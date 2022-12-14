using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.User;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models.Product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Type { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        [MinLength(1)]
        public string ImgUrl { get; set; } = null!;
        [Required]
        public bool IsDeleted { get; set; }

        public ICollection<UserProduct> ProductsInCart { get; set; } = new List<UserProduct>();

        public ICollection<InventoryProduct> InventoryProducts { get; set; } = new List<InventoryProduct>();
        public ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    }
}
