using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();

        public ICollection<ProductOrder> ProductOrders { get; set; } = new List<ProductOrder>();

    }
}
