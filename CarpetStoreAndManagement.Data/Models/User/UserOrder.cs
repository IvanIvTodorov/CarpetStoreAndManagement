using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models.User
{
    public class UserOrder
    {
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;
        [Required]
        public bool IsCompleted { get; set; }

    }
}
