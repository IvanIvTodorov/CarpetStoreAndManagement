using System.ComponentModel.DataAnnotations;


namespace CarpetStoreAndManagement.ViewModels.UserViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
