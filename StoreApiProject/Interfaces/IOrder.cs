using StoreApiProject.Models;

namespace StoreApiProject.Interfaces
{
    public interface IOrder { 
    Task<ICollection<Order>> GetOrders();
    Task<Order> GetOrder(int id);
    Task<bool> CreateOrder(Order order);
    Task<bool> UpdateOrder();
    Task<bool> EditOrder(Order order);
    Task<bool> DeleteOrder(int id);
    }
}
