using Store_Api_Proj.Models;

namespace Store_Api_Proj.Interfaces
{
    public interface IOrder { 
    ICollection<Order> GetOrders();
    Order GetOrderById(int id);
    }
}
