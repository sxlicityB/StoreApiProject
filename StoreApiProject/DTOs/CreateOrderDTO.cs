namespace StoreApiProject.DTOs;

public class CreateOrderDTO
{
    public int BuyerId { get; set; }

    public ICollection<CreateOrderProductDTO> OrderProducts { get; set; } = new List<CreateOrderProductDTO>();

}
