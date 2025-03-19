namespace StoreApiProject.Domain.Models
{
    public class OrderProduct
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } //navigational

        public int ProductId { get; set; }
        public Product Product { get; set; } // navigational
        public int Quantity { get; set; }
    }
}
