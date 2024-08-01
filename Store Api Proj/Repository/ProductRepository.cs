using Store_Api_Proj.Data;
using Store_Api_Proj.Interfaces;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.Repository
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
        public Product GetProductById(int id) 
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
