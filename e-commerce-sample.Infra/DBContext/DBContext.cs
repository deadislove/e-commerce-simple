using e_commerce_sample.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerce_sample.Infra.DBContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<CustomerOrder> CustomerOrders { get; set; }

        public DbSet<OrderedProduct> Orderedproducts { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<RegisterModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure default schema
            modelBuilder.HasDefaultSchema("Admin");

            //Map entity to table
            modelBuilder.Entity<Category>().ToTable("Categories", "dbo");
            modelBuilder.Entity<Customer>().ToTable("Customers", "dbo");
            modelBuilder.Entity<Product>().ToTable("Products", "dbo");
            modelBuilder.Entity<CustomerOrder>().ToTable("CustomerOrders", "dbo");
            modelBuilder.Entity<OrderedProduct>().ToTable("Orderedproducts", "dbo");
            modelBuilder.Entity<Cart>().ToTable("Carts", "dbo");
            //Add
            modelBuilder.Entity<RegisterModel>().ToTable("Users", "dbo");

            modelBuilder.Entity<OrderedProduct>().HasKey(key => new {key.ProductId,key.CustomerOrderId });
            modelBuilder.Entity<CustomerOrder>().Property(p => p.Amount).HasColumnType("decimal(5, 2)");
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(5,2)");
        }
    }
}
