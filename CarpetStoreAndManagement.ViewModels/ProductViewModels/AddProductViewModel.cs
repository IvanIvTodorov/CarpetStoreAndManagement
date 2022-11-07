using CarpetStoreAndManagement.Data.Models.Inventory;
using System.ComponentModel.DataAnnotations;


namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class AddProductViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Type { get; set; }
        [Required]
        [Range(typeof(decimal), "0.0", "50")]

        public decimal Price { get; set; }
        [Required]
        public string? ImgUrl { get; set; }
        [Required]
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
    }
}
