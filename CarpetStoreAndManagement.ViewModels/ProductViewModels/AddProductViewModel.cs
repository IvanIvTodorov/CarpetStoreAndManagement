using CarpetStoreAndManagement.Data.Models.Inventory;
using System.ComponentModel.DataAnnotations;


namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class AddProductViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string? Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string? Type { get; set; }
        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }
        [Required]
        [MinLength(1)]
        public string? ImgUrl { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string PrimaryColor { get; set; } = null!;
        [MinLength(1)]
        [MaxLength(20)]
        public string? SecondaryColor { get; set; }
    }
}
