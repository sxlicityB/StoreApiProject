namespace StoreApiProject.DTOs
{
    public class CreateOrderDTO
    {
        public int BuyerId { get; set; }

        public List<CreateOrderProductDTO> OrderProducts { get; set; } = new List<CreateOrderProductDTO>();

    }
}
