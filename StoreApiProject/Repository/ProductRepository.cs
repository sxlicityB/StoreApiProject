using StoreApiProject.Data;
using StoreApiProject.Interfaces;
using StoreApiProject.Models;

namespace StoreApiProject.Repository
{
    public class ProductRepository :IProduct
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(x => x.ProductId).ToList();
        }
        public Product GetProduct(int id) 
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
        public bool CreateProduct(Product product)
        {
            _context.Add(product);
            return UpdateProduct();
        }

        public bool UpdateProduct()
        {
            var ProductUpdate = _context.SaveChanges();
            return ProductUpdate > 0;
        }
        public bool EditProduct(Product product)
        {
            _context.Update(product);
            return UpdateProduct();
        }
        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(o => o.ProductId == id);
            _context.Remove(product);
            return UpdateProduct();
        }
    }
}
