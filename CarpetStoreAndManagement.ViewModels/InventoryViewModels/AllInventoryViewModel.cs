﻿using CarpetStoreAndManagement.Data.Models.Inventory;
using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.ViewModels.InventoryViewModels
{
    public class AllInventoryViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string InventoryName { get; set; } = null!;

        public IEnumerable<InventoryProduct> Products { get; set; } = new List<InventoryProduct>();

        public IEnumerable<InventoryRawMaterial> RawMaterials { get; set; } = new List<InventoryRawMaterial>();
    }
}
