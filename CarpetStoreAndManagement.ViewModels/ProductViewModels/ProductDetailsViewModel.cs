using CarpetStoreAndManagement.Data.Models.Product;

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
