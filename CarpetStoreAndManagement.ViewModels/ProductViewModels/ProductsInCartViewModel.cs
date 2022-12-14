namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class ProductsInCartViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImgUrl { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
