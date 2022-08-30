using FlocityClothingStore.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace FlocityClothingStore.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasData(
                new Cart { Id = 1, CustomerId = 5 },
                new Cart { Id = 2, CustomerId = 4 },
                new Cart { Id = 3, CustomerId = 3 },
                new Cart { Id = 4, CustomerId = 2 },
                new Cart { Id = 5, CustomerId = 1 });

            modelBuilder.Entity<CartItem>()
                .HasData(
                new CartItem { Id = 1, ProductId = 1, CartId = 5, Quantity = 2, Size = "S" },
                new CartItem { Id = 2, ProductId = 2, CartId = 4, Quantity = 4, Size = "M" },
                new CartItem { Id = 3, ProductId = 3, CartId = 3, Quantity = 4, Size = "L" },
                new CartItem { Id = 4, ProductId = 4, CartId = 2, Quantity = 8, Size = "S" },
                new CartItem { Id = 5, ProductId = 5, CartId = 1, Quantity = 10, Size = "M" });

            modelBuilder.Entity<Category>()
                .HasData(
                new Category { Id = 1, CategoryName = "Partywear" },
                new Category { Id = 2, CategoryName = "Bridal" },
                new Category { Id = 3, CategoryName = "Unstitched" },
                new Category { Id = 4, CategoryName = "Casual" },
                new Category { Id = 5, CategoryName = "Pret" });

            modelBuilder.Entity<Customer>()
                .HasData(
                new Customer { Id = 1, FullName = "Amber Smith", Email = "Amber2234@gmail.com" },
                new Customer { Id = 2, FullName = "Sonia Bachchan", Email = "SB455@gmail.com" },
                new Customer { Id = 3, FullName = "Madiha Kaur", Email = "MdK@gmail.com" },
                new Customer { Id = 4, FullName = "Sadaf Aslam", Email = "SadafA@gmail.com" },
                new Customer { Id = 5, FullName = "Floria K", Email = "kk@gmail.com" });

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Name = "MEHENDI KI RAAT", Description = "'Mehendi ki Raat' Ready To Wear Three Piece Luxury Formal Women Suit with hand embroidery on apple green, handcrafted with complementing blue and magenta appliqué, kora, dabka and resham work.", Price = 130.00, Size = "M", CategoryId = 1 },
                new Product { Id = 2, Name = "JAHAN ARA", Description = "The most regal and traditional front open kalidaar in a deep crimson, embellished heavily with zardoze and resham. This kalidar is paired with a matching flary banarsi lehenga.  ", Price = 239.99, Size = "M", CategoryId = 2 },
                new Product { Id = 3, Name = "ZEHRIN (THREE PIECE)", Description = "Zehrin is a modern straight cut in pink with heavy thread embroidery on neck and sleeves. The sleeves are finished with cutwork and hand crafted tassels.", Price = 77.00, Size = "S", CategoryId = 3 },
                new Product { Id = 4, Name = "SANORITA", Description = "Loose kurta with embroidery on shoulder, tassel dori on neckline and frill sleeves. ", Price = 50.00, Size = "M", CategoryId = 4 },
                new Product { Id = 5, Name = "MALHAAR", Description = "katan zari lining embroidered shirt with adda work\r\nKatan zari dupatta with lace Jamawar tehra trouser ", Price = 149.99, Size = "M", CategoryId = 5 });

            modelBuilder.Entity<Transaction>()
             .HasData(
                new Transaction { Id = 1, ProductId = 5, CustomerId = 1, Quantity = 2, DateOfTransaction = DateTime.Now },
                new Transaction { Id = 2, ProductId = 4, CustomerId = 2, Quantity = 4, DateOfTransaction = DateTime.Now },
                new Transaction { Id = 3, ProductId = 3, CustomerId = 3, Quantity = 6, DateOfTransaction = DateTime.Now },
                new Transaction { Id = 4, ProductId = 2, CustomerId = 4, Quantity = 8, DateOfTransaction = DateTime.Now },
                new Transaction { Id = 5, ProductId = 1, CustomerId = 5, Quantity = 10, DateOfTransaction = DateTime.Now });

        }
    }

}



