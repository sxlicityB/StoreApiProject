namespace Store_Api_Proj.Data;
using Store_Api_Proj.Models;
using Bogus;
using Store_Api_Proj.Interfaces;
using System.Linq;

public class GenerateMockData
{
    private readonly IOrder _orderRepository;
    private readonly IBuyer _buyerRepository;
    private readonly IProduct _productRepository;

    public GenerateMockData(IOrder orderRepository, IBuyer buyerRepository, IProduct productRepository)
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

        var randomBuyerId = new Faker().Random.Number(minBuyerId, maxBuyerId);
        var randomBuyer = _buyerRepository.GetBuyer(randomBuyerId);

        var randomStatus = new Faker().PickRandom<Order.OrderStatus>();

        var faker = new Faker<Order>()
            .StrictMode(false)
            .RuleFor(o => o.OrderId, maxOrderId++)
            .RuleFor(o => o.BuyerId, randomBuyerId)
            .RuleFor(o => o.Buyer, randomBuyer)
            .RuleFor(o => o.OrderProducts, new List<OrderProduct>())
            .RuleFor(o => o.Status, randomStatus)
            .RuleFor(o => o.TotalPrice, 0);

        var newOrder = faker.Generate();
        newOrder.TotalPrice = newOrder.CalculateTotalPrice();

        _orderRepository.CreateOrder(newOrder);
    }

    public void GenerateBuyer()
    {
        int maxBuyerId = _buyerRepository.GetBuyers().Max(o => o.BuyerId);

        var faker = new Faker<Buyer>()
            .StrictMode(false)
            .RuleFor(b => b.BuyerId, maxBuyerId++)
            .RuleFor(b => b.Name, new Faker().Name.FullName())
            .RuleFor(b => b.Orders, new List<Order>());

    }

    public void GenereateProduct()
    {
        int maxProductId = _productRepository.GetProducts().Max(o => o.ProductId);

        var faker = new Faker<Product>()
            .StrictMode(false)
            .RuleFor(p => p.ProductId, maxProductId)
            .RuleFor(p => p.Brand, new Faker().Company.CompanyName())
            .RuleFor(p => p.Type, new Faker().Commerce.Department())
            .RuleFor(p => p.Availability, new Faker().Random.Bool(0.7f))
            .RuleFor(p => p.Price, Convert.ToDecimal(new Faker().Commerce.Price(1, 100)));
            
    }
}
