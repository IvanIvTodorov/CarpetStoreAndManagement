using CarpetStoreAndManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpetStoreAndManagement.Data.Configuration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasData(CreateColors());
        }

        public List<Color> CreateColors()
        {
            var colors = new List<Color>();

            var firstColor = new Color()
            {
                Id = 1,
                Name = "Brown"
            };

            var secondColor = new Color()
            {
                Id = 2,
                Name = "White"
            };

            var thirdColor = new Color()
            {
                Id = 3,
                Name = "Black"
            };

            var forthColor = new Color()
            {
                Id = 4,
                Name = "Orange"
            };

            var fifthColor = new Color()
            {
                Id = 5,
                Name = "Gray"
            };

            var sixstColor = new Color()
            {
                Id = 6,
                Name = "Beige"
            };

            var seventhColor = new Color()
            {
                Id = 7,
                Name = "Green"
            };

            var eightColor = new Color()
            {
                Id = 8,
                Name = "Blue"
            };


            var ninthColor = new Color()
            {
                Id = 9,
                Name = "Dark vision"
            };

            var tenthColor = new Color()
            {
                Id = 10,
                Name = "Dark brown"
            };

            colors.Add(firstColor);
            colors.Add(secondColor);
            colors.Add(thirdColor);
            colors.Add(forthColor);
            colors.Add(fifthColor);
            colors.Add(sixstColor);
            colors.Add(seventhColor);
            colors.Add(eightColor);
            colors.Add(ninthColor);
            colors.Add(tenthColor);

            return colors;
        }
    }
}
