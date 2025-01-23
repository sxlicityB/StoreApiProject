using StoreApiProject.Models;

namespace StoreApiProject.Interfaces
{
    public interface IProduct
    {
        Task<ICollection<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct();
        Task<bool> EditProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
