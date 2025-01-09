using Microsoft.AspNetCore.Http.HttpResults;
using StoreApiProject.Data;
using StoreApiProject.Interfaces;
using StoreApiProject.Models;

namespace StoreApiProject.Repository
{
    public class BuyerRepository : IBuyer
    {
        private readonly AppDbContext _context;
        public BuyerRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Buyer> GetBuyers()
        {
            return _context.Buyers.OrderBy(x => x.BuyerId).ToList();
        }
        public Buyer GetBuyer(int id) 
        {
            return _context.Buyers.FirstOrDefault(b => b.BuyerId == id);
        }

        public bool CreateBuyer(Buyer buyer)
        {
            _context.Add(buyer);
            return UpdateBuyer();
        }

        public bool UpdateBuyer()
        {
            var BuyerUpdate = _context.SaveChanges();
            return BuyerUpdate > 0;
        }
        public bool EditBuyer(Buyer buyer) 
        {
            _context.Update(buyer);
            return UpdateBuyer();
        }
        public bool DeleteBuyer(int id)
        {
            var buyer = _context.Buyers.FirstOrDefault(o => o.BuyerId == id);
            _context.Remove(buyer);
            return UpdateBuyer();
        }
    }
}
