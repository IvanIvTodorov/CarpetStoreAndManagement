﻿using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarpetStoreAndManagement.Data
{
    public class CarpetStoreAndManagementDbContext : IdentityDbContext<User>
    {

        public CarpetStoreAndManagementDbContext(DbContextOptions<CarpetStoreAndManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<InventoryProduct> InventoryProducts { get; set; }
        public DbSet<InventoryRawMaterial> InventoryRawMaterials { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string ROLE_ID = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admins",
                NormalizedName = "ADMINS",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            var user = new User
            {
                Id = ADMIN_ID,
                Email = "xxxx@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "Vanko",
                NormalizedUserName = "VANKO",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            PasswordHasher<User> ph = new PasswordHasher<User>();
            user.PasswordHash = ph.HashPassword(user, "Cska1948!");

            builder.Entity<User>().HasData(user);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });


            builder.Entity<ProductOrder>()
                .HasKey(x => new { x.ProductId, x.OrderId });

            builder.Entity<ProductColor>()
                .HasKey(x => new { x.ProductId, x.ColorId });

            builder.Entity<InventoryProduct>()
                .HasKey(x => new { x.ProductId, x.InventoryId });


            builder.Entity<InventoryRawMaterial>()
                .HasKey(x => new { x.InventoryId, x.RawMaterialId});

            builder.Entity<UserOrder>()
                .HasKey(x => new { x.UserId, x.OrderId });

            builder.Entity<UserProduct>()
                .HasKey(x => new { x.UserId, x.ProductId });

            base.OnModelCreating(builder);
        }

    }
}
