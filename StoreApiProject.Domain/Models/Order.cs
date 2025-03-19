using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreApiProject.Domain.Enums;
namespace StoreApiProject.Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }  // navigational
        public List<OrderProduct> OrderProducts { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice => OrderProducts.Sum(p => p.Product?.Price * p.Quantity ?? 0);
        
    }
}
