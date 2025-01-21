using StoreApiProject.Models;

namespace StoreApiProject.Interfaces
{
    public interface IBuyer
    {
        Task<ICollection<Buyer>> GetBuyers();
        Task<Buyer> GetBuyer(int id);
        Task<bool> CreateBuyer(Buyer buyer);
        Task<bool> UpdateBuyer();
        Task<bool> EditBuyer(Buyer buyer);
        Task<bool> DeleteBuyer(int id);
    }
}
