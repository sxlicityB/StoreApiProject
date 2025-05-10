using StoreApiProject.DAL.Data;
using StoreApiProject.DAL.Interfaces;
using StoreApiProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreApiProject.DAL.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Product>> GetProductsAsync()
    {
        return await _context.Products.OrderBy(x => x.ProductId).ToListAsync();
    }
    public async Task<Product> GetProductAsync(int id) 
    {
        return await _context.Products.FindAsync(id);
    }
    public async Task<bool> CreateProductAsync(Product product)
    {
        _context.Add(product);
        return await UpdateProductAsync();
    }

    public async Task<bool> UpdateProductAsync()
    {
        var ProductUpdate = _context.SaveChanges();
        return ProductUpdate > 0;
    }
    public async Task<bool> EditProductAsync(Product product)
    {
        _context.Update(product);
        return await UpdateProductAsync();
    }
    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = _context.Products.FirstOrDefault(o => o.ProductId == id);
        _context.Remove(product);
        return await UpdateProductAsync();
    }
}
