using StoreApiProject.Data;
using StoreApiProject.Interfaces;
using StoreApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreApiProject.Repository
{
    public class ProductRepository :IProduct
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _context.Products.OrderBy(x => x.ProductId).ToListAsync();
        }
        public async Task<Product> GetProduct(int id) 
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<bool> CreateProduct(Product product)
        {
            _context.Add(product);
            return await UpdateProduct();
        }

        public async Task<bool> UpdateProduct()
        {
            var ProductUpdate = _context.SaveChanges();
            return ProductUpdate > 0;
        }
        public async Task<bool> EditProduct(Product product)
        {
            _context.Update(product);
            return await UpdateProduct();
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(o => o.ProductId == id);
            _context.Remove(product);
            return await UpdateProduct();
        }
    }
}
