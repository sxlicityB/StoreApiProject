using StoreApiProject.Models;

namespace StoreApiProject.Interfaces
{
    public interface IOrder { 
    ICollection<Order> GetOrders();
    Order GetOrder(int id);
    bool CreateOrder(Order order);
    bool UpdateOrder();
    bool EditOrder(Order order);
    bool DeleteOrder(int id);
    }
}
