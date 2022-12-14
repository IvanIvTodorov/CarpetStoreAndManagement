using CarpetStoreAndManagement.Data.Models.Product;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;

        public ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
        public ICollection<RawMaterial> RawMaterials { get; set; } = new List<RawMaterial>();

    }
}
