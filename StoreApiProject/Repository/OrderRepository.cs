using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.Data;
using StoreApiProject.Interfaces;
using StoreApiProject.Models;

namespace StoreApiProject.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<ICollection<Order>> GetOrders() 
        {
            
            return await _context.Orders
                  .Include(o => o.OrderProducts)
                  .ThenInclude(op => op.Product)
                  .Include(o => o.Buyer)
                  .OrderBy(o => o.OrderId).ToListAsync();
        }
        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders
                  .Include(o => o.OrderProducts)
                  .ThenInclude(op => op.Product)
                  .Include(o => o.Buyer)
                  .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task<bool> CreateOrder(Order order)
        {

            await _context.AddAsync(order);
            return await UpdateOrder();    
        }

        public async Task<bool> UpdateOrder()
        {
            var OrderUpdate = await _context.SaveChangesAsync();
            return OrderUpdate > 0;
        }
        public async Task<bool> EditOrder(Order order)
        {
            _context.Update(order);
            return await UpdateOrder();
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return false;

            _context.Remove(order);
            return await UpdateOrder();
        }
    }
}
