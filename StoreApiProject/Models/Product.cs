namespace StoreApiProject.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Brand { get; set; }
        public string? Type { get; set; }
        public bool Availability { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
