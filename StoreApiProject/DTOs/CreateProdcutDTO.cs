namespace StoreApiProject.DTOs;

public class CreateProductDTO
{
    public string? Brand { get; set; }
    public string? Type { get; set; }
    public bool Availability { get; set; }
    public decimal Price { get; set; }
}
