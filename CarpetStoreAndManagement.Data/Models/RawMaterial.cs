using CarpetStoreAndManagement.Data.Models.Enums;
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
        public RawMaterialType Type { get; set; }
        [Required]
        public int ColorId { get; set; }

        public Color Color { get; set; } = null!;

        public ICollection<InventoryRawMaterial> InventoryRawMaterials { get; set; } = new List<InventoryRawMaterial>();

    }
}
