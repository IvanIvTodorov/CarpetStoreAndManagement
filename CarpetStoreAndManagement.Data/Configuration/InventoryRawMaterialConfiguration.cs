using CarpetStoreAndManagement.Data.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Configuration
{
    public class InventoryRawMaterialConfiguration : IEntityTypeConfiguration<InventoryRawMaterial>
    {
        public void Configure(EntityTypeBuilder<InventoryRawMaterial> builder)
        {
            builder.HasData(AddRawMaterialsToInventory());
        }

        private List<InventoryRawMaterial> AddRawMaterialsToInventory()
        {
            var materials = new List<InventoryRawMaterial>();


            var invRawMaterial = new InventoryRawMaterial()
            {
                InventoryId = 1,
                RawMaterialId = 1,
                Quantity = 20

            };

            var invRawMaterial2 = new InventoryRawMaterial()
            {
                InventoryId = 1,
                RawMaterialId = 2,
                Quantity = 20

            };

            var invRawMaterial3 = new InventoryRawMaterial()
            {
                InventoryId = 1,
                RawMaterialId = 3,
                Quantity = 20
            };

            var invRawMaterial4 = new InventoryRawMaterial()
            {
                InventoryId = 1,
                RawMaterialId = 4,
                Quantity = 20
            };

            var invRawMaterial5 = new InventoryRawMaterial()
            {
                InventoryId = 1,
                RawMaterialId = 5,
                Quantity = 20
            };

            var invRawMaterial6 = new InventoryRawMaterial()
            {
                InventoryId = 1,
                RawMaterialId = 6,
                Quantity = 20
            };


            materials.Add(invRawMaterial);
            materials.Add(invRawMaterial2);
            materials.Add(invRawMaterial3);
            materials.Add(invRawMaterial4);
            materials.Add(invRawMaterial5);
            materials.Add(invRawMaterial6);

            return materials;
        }
    }
}
