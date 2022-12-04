using CarpetStoreAndManagement.Data.Configuration;
using CarpetStoreAndManagement.Data.Models;
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

        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<RawMaterial> RawMaterials { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Inventory> Inventories { get; set; } = null!;
        public DbSet<ProductOrder> ProductOrders { get; set; } = null!;
        public DbSet<ProductColor> ProductColors { get; set; } = null!;
        public DbSet<InventoryProduct> InventoryProducts { get; set; } = null!;
        public DbSet<InventoryRawMaterial> InventoryRawMaterials { get; set; } = null!;
        public DbSet<UserOrder> UserOrders { get; set; } = null!;
        public DbSet<UserProduct> UserProducts { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
            builder.ApplyConfiguration(new IdentityUserRoleConfiguration());

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
