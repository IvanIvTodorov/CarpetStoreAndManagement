using CarpetStoreAndManagement.Data.Models.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpetStoreAndManagement.Data.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasData(CreateInventory());
        }

        private Inventory CreateInventory()
        {
            var inventory = new Inventory()
            {
                Id = 1,
                Name = "Central"
            };

            return inventory;
        }
    }
}
