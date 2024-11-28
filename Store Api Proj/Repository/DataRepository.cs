using Bogus;
using Store_Api_Proj.Interfaces;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.Repository
{
    public class DataRepository : IDataService
    {
        private readonly IOrder _orderRepository;
        private readonly IBuyer _buyerRepository;
        private readonly IProduct _productRepository;

        public DataRepository(IOrder orderRepository, IBuyer buyerRepository, IProduct productRepository)
        {
            _orderRepository = orderRepository;
            _buyerRepository = buyerRepository;
            _productRepository = productRepository;
        }

        public void GenerateOrder()
        {
            int maxOrderId = _orderRepository.GetOrders().Max(o => o.OrderId);
            int minBuyerId = _buyerRepository.GetBuyers().Min(o => o.BuyerId);
            int maxBuyerId = _buyerRepository.GetBuyers().Max(o => o.BuyerId);

            int randomBuyerId = new Faker().Random.Number(minBuyerId, maxBuyerId);
            var randomBuyer = _buyerRepository.GetBuyer(randomBuyerId);

            var randomStatus = new Faker().PickRandom<Order.OrderStatus>();

            var faker = new Faker<Order>()
                .StrictMode(false)
                .RuleFor(o => o.BuyerId, randomBuyerId)
                .RuleFor(o => o.Buyer, randomBuyer)
                .RuleFor(o => o.OrderProducts, f => _productRepository.GetProducts()
                    .OrderBy(p => f.Random.Number())
                    .Take(f.Random.Number(1, 10))
                    .Select(p => new OrderProduct
                    {
                        Product = p,
                        ProductId = p.ProductId,
                        Quantity = f.Random.Number(1, 3)
                    })
                    .ToList())
                .RuleFor(o => o.Status, randomStatus);

            _orderRepository.CreateOrder(faker.Generate());
        }

        public void GenerateBuyer()
        {
            int maxBuyerId = _buyerRepository.GetBuyers().Max(o => o.BuyerId);

            var faker = new Faker<Buyer>()
                .StrictMode(false)
                .RuleFor(b => b.Name, new Faker().Name.FullName())
                .RuleFor(b => b.Orders, new List<Order>());

            _buyerRepository.CreateBuyer(faker.Generate());
        }

        public void GenerateProduct()
        {
            int maxProductId = _productRepository.GetProducts().Max(o => o.ProductId);

            var faker = new Faker<Product>()
                .StrictMode(false)
                .RuleFor(p => p.Brand, new Faker().Company.CompanyName())
                .RuleFor(p => p.Type, new Faker().Commerce.Department())
                .RuleFor(p => p.Availability, new Faker().Random.Bool(0.7f))
                .RuleFor(p => p.Price, Convert.ToDecimal(new Faker().Commerce.Price(1, 100)));

            _productRepository.CreateProduct(faker.Generate());
        }

        public void GenerateData()
        {
            GenerateBuyer();
            GenerateProduct();
            GenerateOrder();
        }
    }
}
