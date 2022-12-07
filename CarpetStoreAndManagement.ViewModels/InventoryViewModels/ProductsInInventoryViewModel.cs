using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.ViewModels.InventoryViewModels
{
    public class ProductsInInventoryViewModel
    {
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string InventoryName { get; set; } = null!;
        [Required]
        public string Color { get; set; }
        [Required]
        public string Type { get; set; }

        public IEnumerable<InventoryProduct> Products { get; set; } = new List<InventoryProduct>();
        public IEnumerable<Inventory> Inventories { get; set; } = new List<Inventory>();
        public IEnumerable<Color> Colors { get; set; } = new List<Color>();
        public IEnumerable<string> Types { get; set; } = new List<string>();

    }
}
