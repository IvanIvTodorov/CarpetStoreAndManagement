﻿// <auto-generated />
using System;
using CarpetStoreAndManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarpetStoreAndManagement.Data.Migrations
{
    [DbContext(typeof(CarpetStoreAndManagementDbContext))]
    partial class CarpetStoreAndManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brown"
                        },
                        new
                        {
                            Id = 2,
                            Name = "White"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Black"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Orange"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Gray"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Beige"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Green"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Blue"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Dark vision"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Dark brown"
                        });
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Inventory.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Central"
                        });
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Inventory.InventoryProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "InventoryId");

                    b.HasIndex("InventoryId");

                    b.ToTable("InventoryProducts");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Inventory.InventoryRawMaterial", b =>
                {
                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("RawMaterialId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InventoryId", "RawMaterialId");

                    b.HasIndex("RawMaterialId");

                    b.ToTable("InventoryRawMaterials");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImgUrl = "https://www.e-kilimi.com/uploads/com_article/gallery/062da0dfa1b262854b14a04c0f91e3d4ed2e8086.jpg",
                            IsDeleted = false,
                            Name = "Nehir",
                            Price = 10.5m,
                            Type = "Carpet"
                        },
                        new
                        {
                            Id = 2,
                            ImgUrl = "https://www.e-kilimi.com/uploads/com_article/gallery/0cde9e862fcf46270e1cb5d6c5c61656eb6ce3a3.jpg",
                            IsDeleted = false,
                            Name = "Sahar",
                            Price = 8.5m,
                            Type = "Carpet"
                        },
                        new
                        {
                            Id = 3,
                            ImgUrl = "https://www.e-kilimi.com/uploads/com_article/gallery/57b812b1fffaea9b8a309adb18594d805f3f81f9.jpg",
                            IsDeleted = false,
                            Name = "Bahar",
                            Price = 15.5m,
                            Type = "Carpet"
                        },
                        new
                        {
                            Id = 4,
                            ImgUrl = "https://domtextilu.s14.cdn-upgates.com/_cache/7/f/7fd25c6864f8df5af92d438c386d6730.jpg",
                            IsDeleted = false,
                            Name = "Sofia",
                            Price = 10.5m,
                            Type = "Carpet"
                        },
                        new
                        {
                            Id = 5,
                            ImgUrl = "https://m.media-amazon.com/images/I/51o3KTsZqUL._AC_SY580_.jpg",
                            IsDeleted = false,
                            Name = "Amaya",
                            Price = 9.5m,
                            Type = "Carpet"
                        },
                        new
                        {
                            Id = 6,
                            ImgUrl = "https://m.media-amazon.com/images/I/51KuKwOewHL._AC_.jpg",
                            IsDeleted = false,
                            Name = "Amira",
                            Price = 10.5m,
                            Type = "Carpet"
                        },
                        new
                        {
                            Id = 7,
                            ImgUrl = "https://kilimi.com/wp-content/uploads/2021/09/Ednotsvetna-pateka-Bela-Bezhov-1.jpg",
                            IsDeleted = false,
                            Name = "Alisa",
                            Price = 10.5m,
                            Type = "Path"
                        },
                        new
                        {
                            Id = 8,
                            ImgUrl = "https://kilimi.com/wp-content/uploads/2021/11/Moderna-pateka-Atlas-878-Tamen-Vizon.jpg",
                            IsDeleted = false,
                            Name = "Vision",
                            Price = 14.5m,
                            Type = "Path"
                        },
                        new
                        {
                            Id = 9,
                            ImgUrl = "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Siv.jpg",
                            IsDeleted = false,
                            Name = "Checkmate",
                            Price = 10.5m,
                            Type = "Path"
                        },
                        new
                        {
                            Id = 10,
                            ImgUrl = "https://kilimi.com/wp-content/uploads/2021/11/Moderna-pateka-Atlas-855-Tamno-Kafyav.jpg",
                            IsDeleted = false,
                            Name = "Siera",
                            Price = 17.5m,
                            Type = "Path"
                        },
                        new
                        {
                            Id = 11,
                            ImgUrl = "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Bezhov-Zelen.jpg",
                            IsDeleted = false,
                            Name = "Modern",
                            Price = 16.5m,
                            Type = "Path"
                        },
                        new
                        {
                            Id = 12,
                            ImgUrl = "https://kilimi.com/wp-content/uploads/2021/05/Moderna-pateka-Iris-596-Bezhov-Oranzhev.jpg",
                            IsDeleted = false,
                            Name = "Modern",
                            Price = 18.5m,
                            Type = "Path"
                        });
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Product.ProductColor", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ColorId");

                    b.HasIndex("ColorId");

                    b.ToTable("ProductColors");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ColorId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            ColorId = 5
                        },
                        new
                        {
                            ProductId = 3,
                            ColorId = 6
                        },
                        new
                        {
                            ProductId = 4,
                            ColorId = 7
                        },
                        new
                        {
                            ProductId = 5,
                            ColorId = 2
                        },
                        new
                        {
                            ProductId = 5,
                            ColorId = 8
                        },
                        new
                        {
                            ProductId = 6,
                            ColorId = 2
                        },
                        new
                        {
                            ProductId = 6,
                            ColorId = 7
                        },
                        new
                        {
                            ProductId = 7,
                            ColorId = 6
                        },
                        new
                        {
                            ProductId = 8,
                            ColorId = 9
                        },
                        new
                        {
                            ProductId = 9,
                            ColorId = 2
                        },
                        new
                        {
                            ProductId = 9,
                            ColorId = 3
                        },
                        new
                        {
                            ProductId = 10,
                            ColorId = 10
                        },
                        new
                        {
                            ProductId = 11,
                            ColorId = 6
                        },
                        new
                        {
                            ProductId = 11,
                            ColorId = 7
                        },
                        new
                        {
                            ProductId = 12,
                            ColorId = 6
                        },
                        new
                        {
                            ProductId = 12,
                            ColorId = 4
                        });
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Product.ProductOrder", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.RawMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.ToTable("RawMaterials");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.User.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "41d1aea7-5764-4ebb-8a0d-055594610abb",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "004571f1-9ed2-4db4-86ff-122c19943354",
                            Email = "ivan@abv.bg",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "IVAN@ABV.BG",
                            NormalizedUserName = "IVAN",
                            PasswordHash = "AQAAAAEAACcQAAAAEM9L/NoIMC977V69+Fdv7qfIxh8JvXR+gzNBtoaeo1WBf1Dk0nD5Ai/VWrG/ConPlQ==",
                            PhoneNumber = "+111111111111",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "41d1aea7-5764-4ebb-8a0d-055594610abb",
                            TwoFactorEnabled = false,
                            UserName = "Ivan"
                        });
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.User.UserOrder", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("UserOrders");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.User.UserProduct", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserProducts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dc68c20c-33c1-4737-9e5e-16b8384e8977",
                            ConcurrencyStamp = "dc68c20c-33c1-4737-9e5e-16b8384e8977",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2148ea66-d73d-4636-9cc7-22bfaa9796ba",
                            ConcurrencyStamp = "2148ea66-d73d-4636-9cc7-22bfaa9796ba",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "41d1aea7-5764-4ebb-8a0d-055594610abb",
                            RoleId = "dc68c20c-33c1-4737-9e5e-16b8384e8977"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Inventory.InventoryProduct", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.Inventory.Inventory", "Inventory")
                        .WithMany("InventoryProducts")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpetStoreAndManagement.Data.Models.Product.Product", "Product")
                        .WithMany("InventoryProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Inventory.InventoryRawMaterial", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.Inventory.Inventory", "Inventory")
                        .WithMany("InventoryRawMaterials")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpetStoreAndManagement.Data.Models.RawMaterial", "RawMaterial")
                        .WithMany("InventoryRawMaterials")
                        .HasForeignKey("RawMaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("RawMaterial");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Product.ProductColor", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.Color", "Color")
                        .WithMany("ProductColors")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpetStoreAndManagement.Data.Models.Product.Product", "Product")
                        .WithMany("ProductColors")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Product.ProductOrder", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpetStoreAndManagement.Data.Models.Product.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.RawMaterial", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.Color", "Color")
                        .WithMany("RawMaterials")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.User.UserOrder", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.Order", "Order")
                        .WithMany("UserOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpetStoreAndManagement.Data.Models.User.User", "User")
                        .WithMany("UserOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.User.UserProduct", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.Product.Product", "Product")
                        .WithMany("ProductsInCart")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpetStoreAndManagement.Data.Models.User.User", "User")
                        .WithMany("ProductsInCart")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpetStoreAndManagement.Data.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CarpetStoreAndManagement.Data.Models.User.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Color", b =>
                {
                    b.Navigation("ProductColors");

                    b.Navigation("RawMaterials");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Inventory.Inventory", b =>
                {
                    b.Navigation("InventoryProducts");

                    b.Navigation("InventoryRawMaterials");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Order", b =>
                {
                    b.Navigation("ProductOrders");

                    b.Navigation("UserOrders");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.Product.Product", b =>
                {
                    b.Navigation("InventoryProducts");

                    b.Navigation("ProductColors");

                    b.Navigation("ProductOrders");

                    b.Navigation("ProductsInCart");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.RawMaterial", b =>
                {
                    b.Navigation("InventoryRawMaterials");
                });

            modelBuilder.Entity("CarpetStoreAndManagement.Data.Models.User.User", b =>
                {
                    b.Navigation("ProductsInCart");

                    b.Navigation("UserOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
