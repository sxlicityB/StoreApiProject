using static Store_Api_Proj.Models.Order;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.DTOs
{
    public class UpdateOrderDTO
    {
        public int OrderId { get; set; }
        public int BuyerId { get; set; }
        public OrderStatus Status { get; set; }
        //public List<UpdateOrderProductDTO> OrderProducts { get; set; } = new List<UpdateOrderProductDTO>();

    }
}
