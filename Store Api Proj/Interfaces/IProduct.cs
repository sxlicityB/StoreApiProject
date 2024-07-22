using Store_Api_Proj.Models;

namespace Store_Api_Proj.Interfaces
{
    public interface IProduct
    {
        ICollection<Product> GetProducts();
    }
}
