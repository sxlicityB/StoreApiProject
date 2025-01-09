using StoreApiProject.Models;

namespace StoreApiProject.Interfaces
{
    public interface IProduct
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        bool CreateProduct(Product product);
        bool UpdateProduct();
        bool EditProduct(Product product);
        bool DeleteProduct(int id);
    }
}
