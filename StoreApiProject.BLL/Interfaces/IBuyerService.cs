using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApiProject.DAL.Projections;
using StoreApiProject.Domain.Models;

namespace StoreApiProject.BLL.Interfaces
{
    public interface IBuyerService
    {
        Task<ICollection<Buyer>> GetBuyersAsync();
        Task<Buyer> GetBuyerAsync(int id);
        Task<List<BuyerWithOrdersProjection>> GetBuyerWithOrdersAsync();
        Task<bool> CreateBuyerAsync(Buyer buyer);
        Task<bool> UpdateBuyerAsync();
        Task<bool> EditBuyerAsync(Buyer buyer);
        Task<bool> DeleteBuyerAsync(int id);
    }
}
