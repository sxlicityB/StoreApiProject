namespace Store_Api_Proj.DTOs
{
    public class CreateOrderDTO
    {
        public int BuyerId { get; set; }

        public List<CreateOrderProductDTO> OrderProducts { get; set; } = new List<CreateOrderProductDTO>();

        /*public CreateOrderDTO()
        {
            OrderProducts = new List<CreateOrderProductDTO>();
        }*/
    }
}
