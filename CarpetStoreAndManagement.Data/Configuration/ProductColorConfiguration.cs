using CarpetStoreAndManagement.Data.Models.Enums;
using CarpetStoreAndManagement.Data.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarpetStoreAndManagement.Data.Configuration
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasData(AddProductColor());
        }

        public List<ProductColor> AddProductColor()
        {
            var productColors = new List<ProductColor>();

            var first = new ProductColor()
            {
                ColorId = 1,
                ProductId = 1,
                ColorType = ProductColorType.PrimaryColor
            };

            var second = new ProductColor()
            {
                ColorId = 5,
                ProductId = 2,
                ColorType = ProductColorType.PrimaryColor
            };

            var third = new ProductColor()
            {
                ColorId = 6,
                ProductId = 3,
                ColorType = ProductColorType.PrimaryColor
            };

            var forth = new ProductColor()
            {
                ColorId = 7,
                ProductId = 4,
                ColorType = ProductColorType.PrimaryColor
            };

            var fifth = new ProductColor()
            {
                ColorId = 2,
                ProductId = 5,
                ColorType = ProductColorType.PrimaryColor
            };

            var sixst = new ProductColor()
            {
                ColorId = 8,
                ProductId = 5,
                ColorType = ProductColorType.SecondaryColor

            };

            var seventh = new ProductColor()
            {
                ColorId = 2,
                ProductId = 6,
                ColorType = ProductColorType.PrimaryColor
            };

            var eight = new ProductColor()
            {
                ColorId = 7,
                ProductId = 6,
                ColorType = ProductColorType.SecondaryColor

            };

            var ninth = new ProductColor()
            {
                ColorId = 6,
                ProductId = 7,
                ColorType = ProductColorType.PrimaryColor
            };

            var tenth = new ProductColor()
            {
                ColorId = 9,
                ProductId = 8,
                ColorType = ProductColorType.PrimaryColor
            };

            var eleventh = new ProductColor()
            {
                ColorId = 2,
                ProductId = 9,
                ColorType = ProductColorType.PrimaryColor
            };

            var twelfth = new ProductColor()
            {
                ColorId = 3,
                ProductId = 9,
                ColorType = ProductColorType.SecondaryColor

            };

            var fourteenth = new ProductColor()
            {
                ColorId = 10,
                ProductId = 10,
                ColorType = ProductColorType.PrimaryColor
            };

            var fifteenth = new ProductColor()
            {
                ColorId = 6,
                ProductId = 11,
                ColorType = ProductColorType.PrimaryColor
            };

            var sixteenth = new ProductColor()
            {
                ColorId = 7,
                ProductId = 11,
                ColorType = ProductColorType.SecondaryColor

            };

            var seventeenth = new ProductColor()
            {
                ColorId = 6,
                ProductId = 12,
                ColorType = ProductColorType.PrimaryColor
            };

            var eighteenth = new ProductColor()
            {
                ColorId = 4,
                ProductId = 12,
                ColorType = ProductColorType.SecondaryColor
            };

            productColors.Add(first);
            productColors.Add(second);
            productColors.Add(third);
            productColors.Add(forth);
            productColors.Add(fifth);
            productColors.Add(sixst);
            productColors.Add(seventh);
            productColors.Add(eight);
            productColors.Add(ninth);
            productColors.Add(tenth);
            productColors.Add(eleventh);
            productColors.Add(twelfth);
            productColors.Add(fourteenth);
            productColors.Add(fifteenth);
            productColors.Add(sixteenth);
            productColors.Add(seventeenth);
            productColors.Add(eighteenth);

            return productColors;
        }
    }
}
