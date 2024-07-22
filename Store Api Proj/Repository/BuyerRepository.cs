using Microsoft.AspNetCore.Http.HttpResults;
using Store_Api_Proj.Data;
using Store_Api_Proj.Interfaces;
using Store_Api_Proj.Models;

namespace Store_Api_Proj.Repository
{
    public class BuyerRepository : IBuyer
    {
        private readonly AppDbContext _context;
        public BuyerRepository(AppDbContext context)
        {
            context = _context;
        }

        public ICollection<Buyer> GetBuyers()
        {
            return _context.Buyers.OrderBy(x => x.BuyerId).ToList();
        }
    }
}
