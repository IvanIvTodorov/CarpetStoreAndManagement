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
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Type { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? ImgUrl { get; set; }
        [Required]
        public string PrimaryColor { get; set; } = null!;
        public string? SecondaryColor { get; set; }
    }
}
