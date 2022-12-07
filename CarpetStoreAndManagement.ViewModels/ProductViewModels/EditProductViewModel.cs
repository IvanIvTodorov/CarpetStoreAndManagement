using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.ViewModels.ProductViewModels
{
    public class EditProductViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Name { get; set; } = null!;
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Type { get; set; } = null!;
        [Required]
        [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }
        [Required]
        [MinLength(1)]
        public string ImgUrl { get; set; } = null!;
        [Required]
        [MinLength(1)]
        [MaxLength(20)]

        public string PrimaryColor { get; set; } = null!;
        [MinLength(1)]
        [MaxLength(20)]
        public string? SecondaryColor { get; set; }
    }
}
