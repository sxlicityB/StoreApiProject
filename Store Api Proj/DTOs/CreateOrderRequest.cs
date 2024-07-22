using static Store_Api_Proj.Models.Order;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.DTOs
{
    public class CreateOrderRequest
    {
        public int OrderId { get; set; }
        public Buyer? Buyer { get; set; }
        public List<int> ProductId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice { get; set; }
    }
}
