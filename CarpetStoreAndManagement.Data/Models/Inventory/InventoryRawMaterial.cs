using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetStoreAndManagement.Data.Models.Inventory
{
    public class InventoryRawMaterial
    {
        public int RawMaterialId { get; set; }

        public RawMaterial RawMaterial { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public int Quantity { get; set; }

    }
}
