using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        public ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    }
}
