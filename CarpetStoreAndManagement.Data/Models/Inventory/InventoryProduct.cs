using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models.Inventory
{
    public class InventoryProduct
    {
        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        public int ProductId { get; set; }

        public Product.Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
