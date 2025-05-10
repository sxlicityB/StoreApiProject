using Bogus;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.DAL.Data;
using StoreApiProject.DAL.Interfaces;
using StoreApiProject.Domain.Models;
using StoreApiProject.Domain.Enums;
using System.Security.Cryptography;
using StoreApiProject.Domain.Enums;
using System.Data;

namespace StoreApiProject.DAL.Repository;

public class DataRepository : IDataRepository
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBuyerRepository _buyerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IAppUserRepository _appUserRepository;
    private readonly AppDbContext _context;

    public DataRepository(IOrderRepository orderRepository, IBuyerRepository buyerRepository, IProductRepository productRepository, IAppUserRepository appUserRepository, AppDbContext context)
    {
        _orderRepository = orderRepository;
        _buyerRepository = buyerRepository;
        _productRepository = productRepository;
        _appUserRepository = appUserRepository;
        _context = context;
    }

    public async Task GenerateOrderAsync()
    {
        var buyers = await _buyerRepository.GetBuyersAsync();
        int minBuyerId = buyers.Min(o => o.BuyerId);
        int maxBuyerId = buyers.Max(o => o.BuyerId);

        int randomBuyerId = new Faker().Random.Number(minBuyerId, maxBuyerId);
        var randomBuyer = await _buyerRepository.GetBuyerAsync(randomBuyerId);

        var randomStatus = new Faker().PickRandom<OrderStatus>();

        var orderProducts = await _productRepository.GetProductsAsync();

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
                    Quantity = f.Random.Number(1, 3),
                    UnitPrice = p.Price
                })
                .ToList())
            .RuleFor(o => o.Status, randomStatus);

        await _orderRepository.CreateOrderAsync(faker.Generate());
    }

    public async Task GenerateBuyerAsync()
    {

        var users = await _appUserRepository.GetUsersAsync();
        int minUserId = users.Min(u => u.UserId);
        int maxUserId = users.Max(u => u.UserId);

        int randomUserId = new Faker().Random.Number(minUserId, maxUserId);

        var randomUser = await _appUserRepository.GetUserAsync(randomUserId);

        var faker = new Faker<Buyer>()
            .StrictMode(false)
            .RuleFor(b => b.Name, new Faker().Name.FullName())
            .RuleFor(b => b.Orders, new List<Order>())
            .RuleFor(b => b.UserId, randomUserId)
            .RuleFor(b => b.User, randomUser);

        await _buyerRepository.CreateBuyerAsync(faker.Generate());
    }

    public async Task GenerateProductAsync()
    {

        var faker = new Faker<Product>()
            .StrictMode(false)
            .RuleFor(p => p.Brand, new Faker().Company.CompanyName())
            .RuleFor(p => p.Type, new Faker().Commerce.Department())
            .RuleFor(p => p.Availability, new Faker().Random.Bool(0.7f))
            .RuleFor(p => p.Price, Convert.ToDecimal(new Faker().Commerce.Price(1, 100)));

        await _productRepository.CreateProductAsync(faker.Generate());
    }

    public async Task GenerateAppUserAsync()
    {
        var faker = new Faker<AppUser>()
            .StrictMode(false)
            .RuleFor(u => u.Email, new Faker().Internet.Email())
            .RuleFor(u => u.Username, new Faker().Internet.UserName())
            .RuleFor(u => u.PasswordHash, new Faker().Internet.Password())
            .RuleFor(u => u.Role, AppUserRole.User.ToString);

        await _appUserRepository.CreateUserAsync(faker.Generate());

    }

    public async Task GenerateDataAsync()
    {
        await GenerateBuyerAsync();
        await GenerateProductAsync();
        await GenerateOrderAsync();
    }

    public async Task ResetDatabaseAsync()
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
