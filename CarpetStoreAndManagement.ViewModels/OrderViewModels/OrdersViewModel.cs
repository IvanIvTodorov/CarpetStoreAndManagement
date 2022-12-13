using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.ViewModels.OrderViewModels
{
    public class OrdersViewModel
    {
        public int OrderId { get; set; }

        public string ClientName { get; set; }

        public List<string> ProductName { get; set; }

        public List<string> ProductType { get; set; }

        public List<string> PrimaryColor { get; set; }
        public List<string> SecondaryColor { get; set; }

        public List<int> ProductQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
