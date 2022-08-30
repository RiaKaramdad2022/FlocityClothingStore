﻿// <auto-generated />
using System;
using FlocityClothingStore.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlocityClothingStore.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220830152640_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 5
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 4
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 2
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 1
                        });
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CartId = 5,
                            ProductId = 1,
                            Quantity = 2,
                            Size = "S"
                        },
                        new
                        {
                            Id = 2,
                            CartId = 4,
                            ProductId = 2,
                            Quantity = 4,
                            Size = "M"
                        },
                        new
                        {
                            Id = 3,
                            CartId = 3,
                            ProductId = 3,
                            Quantity = 4,
                            Size = "L"
                        },
                        new
                        {
                            Id = 4,
                            CartId = 2,
                            ProductId = 4,
                            Quantity = 8,
                            Size = "S"
                        },
                        new
                        {
                            Id = 5,
                            CartId = 1,
                            ProductId = 5,
                            Quantity = 10,
                            Size = "M"
                        });
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Partywear"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Bridal"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Unstitched"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Casual"
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Pret"
                        });
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Amber2234@gmail.com",
                            FullName = "Amber Smith"
                        },
                        new
                        {
                            Id = 2,
                            Email = "SB455@gmail.com",
                            FullName = "Sonia Bachchan"
                        },
                        new
                        {
                            Id = 3,
                            Email = "MdK@gmail.com",
                            FullName = "Madiha Kaur"
                        },
                        new
                        {
                            Id = 4,
                            Email = "SadafA@gmail.com",
                            FullName = "Sadaf Aslam"
                        },
                        new
                        {
                            Id = 5,
                            Email = "kk@gmail.com",
                            FullName = "Floria K"
                        });
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "'Mehendi ki Raat' Ready To Wear Three Piece Luxury Formal Women Suit with hand embroidery on apple green, handcrafted with complementing blue and magenta appliqué, kora, dabka and resham work.",
                            Name = "MEHENDI KI RAAT",
                            Price = 130.0,
                            Size = "M"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "The most regal and traditional front open kalidaar in a deep crimson, embellished heavily with zardoze and resham. This kalidar is paired with a matching flary banarsi lehenga.  ",
                            Name = "JAHAN ARA",
                            Price = 239.99000000000001,
                            Size = "M"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Zehrin is a modern straight cut in pink with heavy thread embroidery on neck and sleeves. The sleeves are finished with cutwork and hand crafted tassels.",
                            Name = "ZEHRIN (THREE PIECE)",
                            Price = 77.0,
                            Size = "S"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            Description = "Loose kurta with embroidery on shoulder, tassel dori on neckline and frill sleeves. ",
                            Name = "SANORITA",
                            Price = 50.0,
                            Size = "M"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            Description = "katan zari lining embroidered shirt with adda work\r\nKatan zari dupatta with lace Jamawar tehra trouser ",
                            Name = "MALHAAR",
                            Price = 149.99000000000001,
                            Size = "M"
                        });
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfTransaction")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            DateOfTransaction = new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(580),
                            ProductId = 5,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            DateOfTransaction = new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(615),
                            ProductId = 4,
                            Quantity = 4
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            DateOfTransaction = new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(616),
                            ProductId = 3,
                            Quantity = 6
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            DateOfTransaction = new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(618),
                            ProductId = 2,
                            Quantity = 8
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            DateOfTransaction = new DateTime(2022, 8, 30, 11, 26, 40, 3, DateTimeKind.Local).AddTicks(620),
                            ProductId = 1,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Cart", b =>
                {
                    b.HasOne("FlocityClothingStore.Server.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.CartItem", b =>
                {
                    b.HasOne("FlocityClothingStore.Server.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlocityClothingStore.Server.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Product", b =>
                {
                    b.HasOne("FlocityClothingStore.Server.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Transaction", b =>
                {
                    b.HasOne("FlocityClothingStore.Server.Models.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlocityClothingStore.Server.Models.Product", "Product")
                        .WithMany("Transactions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Customer", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FlocityClothingStore.Server.Models.Product", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}