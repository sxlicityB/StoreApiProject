using static StoreApiProject.Models.Order;
using StoreApiProject.Models;

namespace StoreApiProject.DTOs
{
    public class GetOrderDTO
    {
        public int OrderId { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public List<OrderProductDTO> Products { get; set; } = new List<OrderProductDTO>();
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
