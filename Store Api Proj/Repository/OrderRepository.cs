using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.Data;
using Store_Api_Proj.Interfaces;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) 
        {
            _context = context;
        }

        public ICollection<Order> GetOrders() 
        {
            
            return _context.Orders
                  .Include(o => o.OrderProducts)
                  .ThenInclude(op => op.Product)
                  .Include(o => o.Buyer)
                  .OrderBy(o => o.OrderId).ToList();
        }
        public Order GetOrder(int id)
        {
            return _context.Orders
                  .Include(o => o.OrderProducts)
                  .ThenInclude(op => op.Product)
                  .Include(o => o.Buyer)
                  .FirstOrDefault(o => o.OrderId == id);
        }

        public bool CreateOrder(Order order)
        {

            //order.TotalPrice = order.CalculateTotalPrice();

            _context.Add(order);
            return UpdateOrder();    
        }

        public bool UpdateOrder()
        {
            var OrderUpdate = _context.SaveChanges();
            return OrderUpdate > 0;
        }
        public bool EditOrder(Order order)
        {
            _context.Update(order);
            return UpdateOrder();
        }

        public bool DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == id);
            _context.Remove(order);
            return UpdateOrder();
        }
    }
}
