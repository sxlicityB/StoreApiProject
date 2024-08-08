using Microsoft.AspNetCore.Http.HttpResults;
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
            context = _context;
        }

        public ICollection<Order> GetOrders() 
        {
            return _context.Orders.OrderBy(o => o.OrderId).ToList();
        }
        public Order GetOrder(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.OrderId == id);
        }
    }
}
