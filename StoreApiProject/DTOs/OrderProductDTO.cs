namespace StoreApiProject.DTOs
{
    public class OrderProductDTO
    {
        public int ProductId { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
