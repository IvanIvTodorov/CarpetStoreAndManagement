namespace CarpetStoreAndManagement.Data.Models.User
{
    public class UserProduct
    {
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public int ProductId { get; set; }
        public Product.Product Product { get; set; } = null!;

        public int Quantity { get; set; }

    }
}
