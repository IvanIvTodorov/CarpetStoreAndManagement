using CarpetStoreAndManagement.Data.Models;
using CarpetStoreAndManagement.Data.Models.Inventory;
using CarpetStoreAndManagement.Data.Models.Product;
using CarpetStoreAndManagement.Data.Models.User;
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

        public DbSet<Loom> Looms { get; set; }
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
