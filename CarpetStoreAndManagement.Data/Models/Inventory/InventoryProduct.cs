using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
