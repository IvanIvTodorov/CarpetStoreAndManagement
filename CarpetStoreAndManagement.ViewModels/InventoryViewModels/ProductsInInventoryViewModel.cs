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

        public IEnumerable<InventoryProduct> Products { get; set; } = new List<InventoryProduct>();
    }
}
