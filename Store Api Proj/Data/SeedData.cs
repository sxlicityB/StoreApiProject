using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.Data
{
    public class SeedData
    {
        private readonly AppDbContext _context;
        public SeedData(AppDbContext context)
        {
            _context = context;
        }
        public void SeedDatabase()
        {
            using (var context = _context)
            {
                // Check if the database has been seeded
                /*if (context.Buyers.Any() || context.Products.Any())
                {
                    return;   // DB has been seeded
                }*/

                // Seed Products
                var products = new List<Product>
            {
                new Product { Brand = "Lays", Type = "Groceries", Availability = true, Price = 15.99m },
                new Product { Brand = "Samsung", Type = "Galaxy", Availability = true, Price = 899.99m },
                new Product { Brand = "Sony", Type = "Headphones", Availability = true, Price = 199.99m }
            };

                context.Products.AddRange(products);

                // Seed Buyers
                var buyers = new List<Buyer>
            {
                new Buyer { Name = "John Doe" },
                new Buyer { Name = "Jane Smith" },
                new Buyer { Name = "Joey Diaz" },
                new Buyer { Name = "Steve Jobs" }
            };

                context.Buyers.AddRange(buyers);
                _context.SaveChanges();

                // Seed Orders
                var orders = new List<Order>
            {
                new Order { BuyerId = buyers[0].BuyerId, Status = Order.OrderStatus.Pending, TotalPrice = 1199.98m },
                new Order { BuyerId = buyers[1].BuyerId, Status = Order.OrderStatus.Shipped, TotalPrice = 199.99m }
            };

                context.Orders.AddRange(orders);
                _context.SaveChanges();

                // Seed OrderProducts
                var orderProducts = new List<OrderProduct>
            {
                new OrderProduct { OrderId = orders[0].OrderId, ProductId = products[0].ProductId },
                new OrderProduct { OrderId = orders[0].OrderId, ProductId = products[2].ProductId },
                new OrderProduct { OrderId = orders[1].OrderId, ProductId = products[2].ProductId }
            };

                context.OrderProducts.AddRange(orderProducts);

                // Save all changes to the database
                context.SaveChanges();
            }
        }
    }
}
