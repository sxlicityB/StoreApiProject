using StoreApiProject.Domain.Models;

namespace StoreApiProject.BLL.Interfaces;

public interface IProductService
{
    Task<ICollection<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(int id);
    Task<bool> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync();
    Task<bool> EditProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
}
