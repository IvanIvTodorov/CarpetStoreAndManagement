using Microsoft.AspNetCore.Identity;


namespace CarpetStoreAndManagement.Data.Models.User
{
    public class User : IdentityUser
    {
        public ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();

        public ICollection<UserProduct> ProductsInCart { get; set; } = new List<UserProduct>();

    }
}
