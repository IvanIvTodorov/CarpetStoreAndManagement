using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models.Product
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Type { get; set; }
        [Required]
        [Range(typeof(decimal), "0.0", "50")]

        public decimal Price { get; set; }
        [Required]
        public string? ImgUrl { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<UserProduct> ProductsInCart { get; set; } = new List<UserProduct>();

        public ICollection<InventoryProduct> InventoryProducts { get; set; } = new List<InventoryProduct>();
        public ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    }
}
