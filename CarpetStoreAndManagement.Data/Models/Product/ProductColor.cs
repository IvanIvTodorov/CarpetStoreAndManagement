using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models.Product
{
    public class ProductColor
    {
        public int ColorId { get; set; }

        public Color Color { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
