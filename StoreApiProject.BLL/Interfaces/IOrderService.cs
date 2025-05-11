using StoreApiProject.Domain.Models;

namespace StoreApiProject.BLL.Interfaces;

public interface IOrderService { 
Task<ICollection<Order>> GetOrdersAsync();
Task<Order> GetOrderAsync(int id);
Task<bool> CreateOrderAsync(Order order);
Task<bool> UpdateOrderAsync();
Task<bool> EditOrderAsync(Order order);
Task<bool> DeleteOrderAsync(int id);
Task<bool> ValidateAndProcessOrderAsync(Order order);
}
