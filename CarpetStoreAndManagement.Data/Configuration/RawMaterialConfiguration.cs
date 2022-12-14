using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpetStoreAndManagement.Data.Configuration
{
    public class RawMaterialConfiguration : IEntityTypeConfiguration<RawMaterial>
    {
        public void Configure(EntityTypeBuilder<RawMaterial> builder)
        {
            builder.HasData(CreateRawMaterial());
        }

        private List<RawMaterial> CreateRawMaterial()
        {
            var materials = new List<RawMaterial>();

            var rawMaterial = new RawMaterial()
            {
                Id = 1,
                Type = RawMaterialType.Warp,
                ColorId = 1

            };
            var rawMaterial2 = new RawMaterial()
            {
                Id = 2,
                Type = RawMaterialType.Weft,
                ColorId = 1

            };

            var rawMaterial3 = new RawMaterial()
            {
                Id = 3,
                Type = RawMaterialType.Yarn,
                ColorId = 1

            };

            var rawMaterial4 = new RawMaterial()
            {
                Id = 4,
                Type = RawMaterialType.Warp,
                ColorId = 5

            };
            var rawMaterial5 = new RawMaterial()
            {
                Id = 5,
                Type = RawMaterialType.Weft,
                ColorId = 5

            };

            var rawMaterial6 = new RawMaterial()
            {
                Id = 6,
                Type = RawMaterialType.Yarn,
                ColorId = 5

            };

            materials.Add(rawMaterial);
            materials.Add(rawMaterial2);
            materials.Add(rawMaterial3);
            materials.Add(rawMaterial4);
            materials.Add(rawMaterial5);
            materials.Add(rawMaterial6);

            return materials;
        }
    }
}
