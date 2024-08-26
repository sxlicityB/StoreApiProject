using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Store_Api_Proj.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice { get; set; }
        public decimal CalculateTotalPrice()
        {
            return OrderProducts.Sum(p => p.Product?.Price ?? 0);
        }
        public enum OrderStatus
        {
            Pending,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }
    }
}
