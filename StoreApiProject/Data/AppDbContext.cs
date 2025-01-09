using Microsoft.EntityFrameworkCore;
using StoreApiProject.Models;
namespace StoreApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //One to many relation between Order and Buyer classes
            modelBuilder.Entity<Order>()
            .HasOne(o => o.Buyer)
            .WithMany(b => b.Orders)
            .HasForeignKey(o => o.BuyerId);

            //Many to many relations between Order and Product classes
            modelBuilder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
            .HasOne(o => o.Order)
            .WithMany(op => op.OrderProducts)
            .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
           .HasOne(p => p.Product)
           .WithMany(p => p.OrderProducts)
           .HasForeignKey(op => op.ProductId);

        }
    }
}
