using CarpetStoreAndManagement.Data.Models.Enums;

namespace CarpetStoreAndManagement.Data.Models.Product
{
    public class ProductColor
    {
        public int ColorId { get; set; }

        public Color Color { get; set; } = null!;

        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public ProductColorType ColorType { get; set; }
    }
}
