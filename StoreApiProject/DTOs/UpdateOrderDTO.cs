using static StoreApiProject.Domain.Models.Order;
using StoreApiProject.Domain.Models;

namespace StoreApiProject.DTOs
{
    public class UpdateOrderDTO
    {
        public int OrderId { get; set; }
        public int BuyerId { get; set; }
        public OrderStatus Status { get; set; }

    }
}
