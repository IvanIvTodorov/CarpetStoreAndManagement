using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models.Product
{
    public class ProductOrder
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

    }
}
