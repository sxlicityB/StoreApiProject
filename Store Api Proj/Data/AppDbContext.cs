using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.Models;
namespace Store_Api_Proj.Data
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
        public DbSet<OrderProduct> ProductsProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
