using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.UserViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]

        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5)]

        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]

        public string? ConfirmPassword { get; set; }
    }
}
