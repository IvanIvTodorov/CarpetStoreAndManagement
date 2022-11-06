using CarpetStoreAndManagement.Data.Models.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models
{
    public class RawMaterial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Type { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public int ColorId { get; set; }

        public Color Color { get; set; }

        public ICollection<InventoryRawMaterial> InventoryRawMaterials { get; set; } = new List<InventoryRawMaterial>();

    }
}
