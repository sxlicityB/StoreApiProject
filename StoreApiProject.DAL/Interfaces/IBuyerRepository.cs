using StoreApiProject.Domain.Models;

namespace StoreApiProject.DAL.Interfaces
{
    public interface IBuyerRepository
    {
        Task<ICollection<Buyer>> GetBuyersAsync();
        Task<Buyer> GetBuyerAsync(int id);
        Task<bool> CreateBuyerAsync(Buyer buyer);
        Task<bool> UpdateBuyerAsync();
        Task<bool> EditBuyerAsync(Buyer buyer);
        Task<bool> DeleteBuyerAsync(int id);
    }
}
