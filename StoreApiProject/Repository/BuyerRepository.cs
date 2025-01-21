using Microsoft.AspNetCore.Http.HttpResults;
using StoreApiProject.Data;
using StoreApiProject.Interfaces;
using StoreApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreApiProject.Repository
{
    public class BuyerRepository : IBuyer
    {
        private readonly AppDbContext _context;
        public BuyerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Buyer>> GetBuyers()
        {
            return await _context.Buyers.OrderBy(x => x.BuyerId).ToListAsync();
        }
        public async Task<Buyer> GetBuyer(int id) 
        {
            return await _context.Buyers.FindAsync(id);
        }

        public async Task<bool> CreateBuyer(Buyer buyer)
        {
            await _context.AddAsync(buyer);
            return await UpdateBuyer();
        }

        public async Task<bool> UpdateBuyer()
        {
            var BuyerUpdate = await  _context.SaveChangesAsync();
            return BuyerUpdate > 0;
        }
        public async Task<bool> EditBuyer(Buyer buyer) 
        {
            _context.Update(buyer);
            return await UpdateBuyer();
        }
        public async Task<bool> DeleteBuyer(int id)
        {
            var buyer = await _context.Buyers.FindAsync(id);

            if (buyer == null)
                return false;

            _context.Remove(buyer);
            return await UpdateBuyer();
        }
    }
}
