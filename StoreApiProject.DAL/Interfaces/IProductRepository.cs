using StoreApiProject.Domain.Models;

namespace StoreApiProject.DAL.Interfaces;

public interface IProductRepository
{
    Task<ICollection<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(int id);
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync();
    Task<bool> EditProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
}
