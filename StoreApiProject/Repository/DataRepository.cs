using Bogus;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.Data;
using StoreApiProject.Interfaces;
using StoreApiProject.Models;

namespace StoreApiProject.Repository
{
    public class DataRepository : IDataService
    {
        private readonly IOrder _orderRepository;
        private readonly IBuyer _buyerRepository;
        private readonly IProduct _productRepository;
        private readonly AppDbContext _context;

        public DataRepository(IOrder orderRepository, IBuyer buyerRepository, IProduct productRepository, AppDbContext context)
        {
            _orderRepository = orderRepository;
            _buyerRepository = buyerRepository;
            _productRepository = productRepository;
            _context = context;
        }

        public async Task GenerateOrder()
        {
            var buyers = await _buyerRepository.GetBuyers();
            int minBuyerId = buyers.Min(o => o.BuyerId);
            int maxBuyerId = buyers.Max(o => o.BuyerId);

            int randomBuyerId = new Faker().Random.Number(minBuyerId, maxBuyerId);
            var randomBuyer = await _buyerRepository.GetBuyer(randomBuyerId);

            var randomStatus = new Faker().PickRandom<Order.OrderStatus>();

            var orderProducts = await _productRepository.GetProducts();

            var faker = new Faker<Order>()
                .StrictMode(false)
                .RuleFor(o => o.BuyerId, randomBuyerId)
                .RuleFor(o => o.Buyer, randomBuyer)
                .RuleFor(o => o.OrderProducts, f => orderProducts
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

            await _orderRepository.CreateOrder(faker.Generate());
        }

        public async Task GenerateBuyer()
        {

            var faker = new Faker<Buyer>()
                .StrictMode(false)
                .RuleFor(b => b.Name, new Faker().Name.FullName())
                .RuleFor(b => b.Orders, new List<Order>());

            await _buyerRepository.CreateBuyer(faker.Generate());
        }

        public async Task GenerateProduct()
        {

            var faker = new Faker<Product>()
                .StrictMode(false)
                .RuleFor(p => p.Brand, new Faker().Company.CompanyName())
                .RuleFor(p => p.Type, new Faker().Commerce.Department())
                .RuleFor(p => p.Availability, new Faker().Random.Bool(0.7f))
                .RuleFor(p => p.Price, Convert.ToDecimal(new Faker().Commerce.Price(1, 100)));

            await _productRepository.CreateProduct(faker.Generate());
        }

        public async Task GenerateData()
        {
            await GenerateBuyer();
            await GenerateProduct();
            await GenerateOrder();
        }

        public async Task ResetDatabase()
        {
            _context.Orders.RemoveRange(_context.Orders);
            _context.Products.RemoveRange(_context.Products);
            _context.Buyers.RemoveRange(_context.Buyers);
            await _context.SaveChangesAsync();

            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Orders', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Buyers', RESEED, 0)");
            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Products', RESEED, 0)");
        }
    }
}
