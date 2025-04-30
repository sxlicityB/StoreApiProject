using Microsoft.AspNetCore.Http.HttpResults;
using StoreApiProject.DAL.Data;
using StoreApiProject.DAL.Interfaces;
using StoreApiProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using StoreApiProject.DAL.Projections;

namespace StoreApiProject.DAL.Repository;

public class BuyerRepository : IBuyerRepository
{
    private readonly AppDbContext _context;
    public BuyerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Buyer>> GetBuyersAsync()
    {
        return await _context.Buyers.OrderBy(x => x.BuyerId).ToListAsync();
    }
    public async Task<Buyer> GetBuyerAsync(int id) 
    {
        return await _context.Buyers.FindAsync(id);
    }

    public async Task<List<BuyerWithOrdersProjection>> GetBuyerWithOrdersAsync()
    {
        return await _context.Buyers
        .Select(b => new BuyerWithOrdersProjection
        {
            BuyerId = b.BuyerId,
            Name = b.Name,
            Orders = b.Orders.Select(o => new OrderProjection                       //load up order as projection
            {
                OrderId = o.OrderId,
                Status = o.Status,
                OrderProducts = o.OrderProducts.Select(op => new OrderProductProjection                 //load up OrderProduct as projection correctly
                {
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    Product = op.Product,       //this will load up OrderProducts as well but I think complicating repository just for Null to not show up is exscessive
                    Quantity = op.Quantity,
                    UnitPrice = op.UnitPrice
                }).ToList()
            }).ToList()
        }).ToListAsync();
    }

    public async Task<bool> CreateBuyerAsync(Buyer buyer)
    {
        await _context.AddAsync(buyer);
        return await UpdateBuyerAsync();
    }

    public async Task<bool> UpdateBuyerAsync()
    {
        var BuyerUpdate = await _context.SaveChangesAsync();
        return BuyerUpdate > 0;
    }
    public async Task<bool> EditBuyerAsync(Buyer buyer) 
    {
        _context.Update(buyer);
        return await UpdateBuyerAsync();
    }
    public async Task<bool> DeleteBuyerAsync(int id)
    {
        var buyer = await _context.Buyers.FindAsync(id);

        if (buyer == null)
            return false;

        _context.Remove(buyer);
        return await UpdateBuyerAsync();
    }
}
