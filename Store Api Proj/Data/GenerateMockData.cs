namespace Store_Api_Proj.Data;
using Store_Api_Proj.Models;
using Bogus;
using Store_Api_Proj.Interfaces;
using System.Linq;

public class GenerateMockData
{
    private readonly IOrder _orderRepository;
    private readonly IBuyer _buyerRepository;

    public GenerateMockData(IOrder orderRepository, IBuyer buyerRepository)
    {
        _orderRepository = orderRepository;
        _buyerRepository = buyerRepository;
    }

    public void GenerateOrder()
    {
        int MaxOrderId = _orderRepository.GetOrders().Max(o => o.OrderId);
        int MinBuyerId = _buyerRepository.GetBuyers().Min(o => o.BuyerId);
        int MaxBuyerId = _buyerRepository.GetBuyers().Max(o => o.BuyerId);

        var RandomBuyerId = new Faker().Random.Number(MinBuyerId, MaxBuyerId);
        var RandomBuyer = _buyerRepository.GetBuyer(RandomBuyerId);

        var RandomStatus = new Faker().PickRandom<Order.OrderStatus>();

        var faker = new Faker<Order>()
            .StrictMode(false)
            .RuleFor(o => o.OrderId, MaxOrderId++)
            .RuleFor(o => o.BuyerId, RandomBuyerId)
            .RuleFor(o => o.Buyer, RandomBuyer)
            .RuleFor(o => o.OrderProducts, new List<OrderProduct>())
            .RuleFor(o => o.Status, RandomStatus)
            .RuleFor(o => o.TotalPrice, 0);

        var newOrder = faker.Generate();
        newOrder.TotalPrice = newOrder.CalculateTotalPrice();

        _orderRepository.CreateOrder(newOrder);
    }
}
