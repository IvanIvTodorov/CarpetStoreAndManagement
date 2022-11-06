using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models.User
{
    public class UserProduct
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product.Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
