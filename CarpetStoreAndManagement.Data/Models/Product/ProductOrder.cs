﻿using System.ComponentModel.DataAnnotations;

namespace CarpetStoreAndManagement.Data.Models.Product
{
    public class ProductOrder
    {
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

    }
}
