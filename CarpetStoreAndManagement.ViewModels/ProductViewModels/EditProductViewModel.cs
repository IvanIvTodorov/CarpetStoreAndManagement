using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class EditProductViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3)]

        public string Name { get; set; } = null!;
        [Required]
        [StringLength(10, MinimumLength = 3)]

        public string Type { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        [MinLength(1)]
        public string ImgUrl { get; set; } = null!;
        [Required]
        [StringLength(20, MinimumLength = 1)]


        public string PrimaryColor { get; set; } = null!;
        [StringLength(20, MinimumLength = 1)]

        public string? SecondaryColor { get; set; }
    }
}
