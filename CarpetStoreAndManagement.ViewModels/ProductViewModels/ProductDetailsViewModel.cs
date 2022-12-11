using CarpetStoreAndManagement.Data.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public string ImgUrl { get; set; }

        public string PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
         
        public IEnumerable<Product> Products { get; set; }
    }
}
