using CarpetStoreAndManagement.Data.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ProductId = 1
            };

            var second = new ProductColor()
            {
                ColorId = 5,
                ProductId = 2
            };

            var third = new ProductColor()
            {
                ColorId = 6,
                ProductId = 3
            };

            var forth = new ProductColor()
            {
                ColorId = 7,
                ProductId = 4
            };

            var fifth = new ProductColor()
            {
                ColorId = 2,
                ProductId = 5
            };

            var sixst = new ProductColor()
            {
                ColorId = 8,
                ProductId = 5
            };

            var seventh = new ProductColor()
            {
                ColorId = 2,
                ProductId = 6
            };

            var eight = new ProductColor()
            {
                ColorId = 7,
                ProductId = 6
            };

            var ninth = new ProductColor()
            {
                ColorId = 6,
                ProductId = 7
            };

            var tenth = new ProductColor()
            {
                ColorId = 9,
                ProductId = 8
            };

            var eleventh = new ProductColor()
            {
                ColorId = 2,
                ProductId = 9
            };

            var twelfth = new ProductColor()
            {
                ColorId = 3,
                ProductId = 9
            };

            var fourteenth = new ProductColor()
            {
                ColorId = 10,
                ProductId = 10
            };

            var fifteenth = new ProductColor()
            {
                ColorId = 6,
                ProductId = 11
            };

            var sixteenth = new ProductColor()
            {
                ColorId = 7,
                ProductId = 11
            };

            var seventeenth = new ProductColor()
            {
                ColorId = 6,
                ProductId = 12
            };

            var eighteenth = new ProductColor()
            {
                ColorId = 4,
                ProductId = 12
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
