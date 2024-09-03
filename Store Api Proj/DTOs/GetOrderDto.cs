using static Store_Api_Proj.Models.Order;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.DTOs
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
