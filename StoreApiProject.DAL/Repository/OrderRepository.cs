using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.DAL.Data;
using StoreApiProject.DAL.Interfaces;
using StoreApiProject.Domain.Models;

namespace StoreApiProject.DAL.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context) 
    {
        _context = context;
    }

    public async Task<ICollection<Order>> GetOrdersAsync() 
    {
        
        return await _context.Orders
              .Include(o => o.OrderProducts)
              .ThenInclude(op => op.Product)
              .Include(o => o.Buyer)
              .OrderBy(o => o.OrderId).ToListAsync();
    }
    public async Task<Order> GetOrderAsync(int id)
    {
        return await _context.Orders
              .Include(o => o.OrderProducts)
              .ThenInclude(op => op.Product)
              .Include(o => o.Buyer)
              .FirstOrDefaultAsync(o => o.OrderId == id);
    }

    public async Task<bool> CreateOrderAsync(Order order)
    {

        await _context.AddAsync(order);
        return await UpdateOrderAsync();    
    }

    public async Task<bool> UpdateOrderAsync()
    {
        var OrderUpdate = await _context.SaveChangesAsync();
        return OrderUpdate > 0;
    }
    public async Task<bool> EditOrderAsync(Order order)
    {
        _context.Update(order);
        return await UpdateOrderAsync();
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
            return false;

        _context.Remove(order);
        return await UpdateOrderAsync();
    }
}
