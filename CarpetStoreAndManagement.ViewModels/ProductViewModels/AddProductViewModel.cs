using System.ComponentModel.DataAnnotations;


namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class AddProductViewModel
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string? Type { get; set; }
        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }
        [Required]
        [MinLength(1)]
        public string? ImgUrl { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 1)]
        public string PrimaryColor { get; set; } = null!;
        [StringLength(20, MinimumLength = 1)]

        public string? SecondaryColor { get; set; }
    }
}
