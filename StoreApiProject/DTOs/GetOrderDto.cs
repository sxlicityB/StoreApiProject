using static StoreApiProject.Domain.Models.Order;
using StoreApiProject.Domain.Models;

namespace StoreApiProject.DTOs
{
    public class GetOrderDTO
    {
        public int OrderId { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public ICollection<OrderProductDTO> Products { get; set; } = new List<OrderProductDTO>();
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
