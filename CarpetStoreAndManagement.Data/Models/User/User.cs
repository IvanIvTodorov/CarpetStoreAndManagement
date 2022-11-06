using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace CarpetStoreAndManagement.Data.Models.User
{
    public class User : IdentityUser
    {
        public ICollection<UserOrder> Userorders { get; set; } = new List<UserOrder>();
        [Required]
        public decimal Budget { get; set; }

        public ICollection<UserProduct> ProductsInCart { get; set; } = new List<UserProduct>();

    }
}
