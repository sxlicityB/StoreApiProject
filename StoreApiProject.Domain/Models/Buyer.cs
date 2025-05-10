namespace StoreApiProject.Domain.Models;

public class Buyer
{
    public int BuyerId { get; set; }
    public string? Name { get; set; }
    public int UserId { get; set; }
    public AppUser User { get; set; } = null!;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
