﻿using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.InventoryViewModels
{
    public class RawMaterialsInInventoryViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string InventoryName { get; set; } = null!;
        [Required]
        public string Color { get; set; }
        public IEnumerable<InventoryRawMaterial> RawMaterials { get; set; } = new List<InventoryRawMaterial>();
        public IEnumerable<Inventory> Inventories { get; set; } = new List<Inventory>();
        public IEnumerable<Color> Colors { get; set; } = new List<Color>();
        public IEnumerable<string> Types { get; set; } = new List<string>();
    }
}
