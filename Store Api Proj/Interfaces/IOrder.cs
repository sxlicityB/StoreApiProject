using Store_Api_Proj.Models;

namespace Store_Api_Proj.Interfaces
{
    public interface IOrder { 
    ICollection<Order> GetOrders();
    Order GetOrder(int id);
    bool CreateOrder(Order order);
    bool UpdateOrder();
    bool EditOrder(Order order);
    public bool UpdateOrder(Order order);
    }
}
