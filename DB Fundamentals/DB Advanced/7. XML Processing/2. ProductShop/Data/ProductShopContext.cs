﻿namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using ProductShop.Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public ProductShopContext()
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.conectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasKey(x => new { x.CategoryId, x.ProductId });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(x => x.ProductsSold)
                    .WithOne(x => x.Seller)
                    .HasForeignKey(x => x.SellerId);

                entity.HasMany(x => x.ProductsBought)
                    .WithOne(x => x.Buyer)
                    .HasForeignKey(x => x.BuyerId);
            });
        }
    }
}
