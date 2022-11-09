using CarpetStoreAndManagement.Data.Models.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.ViewModels.RawMaterialViewModels
{
    public class AddRawMaterialViewModel
    {
        [Required]
        public string Color { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public string InventoryName { get; set; }

        public IEnumerable<Inventory> Inventories { get; set; } = new List<Inventory>();
    }
}
