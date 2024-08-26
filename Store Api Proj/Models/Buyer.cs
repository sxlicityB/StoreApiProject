namespace Store_Api_Proj.Models
{
    public class Buyer
    {
        public int BuyerId { get; set; }
        public string? Name { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
