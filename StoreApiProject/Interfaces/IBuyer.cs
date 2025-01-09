using StoreApiProject.Models;

namespace StoreApiProject.Interfaces
{
    public interface IBuyer
    {
        ICollection<Buyer> GetBuyers();
        Buyer GetBuyer(int id);
        bool CreateBuyer(Buyer buyer);
        bool UpdateBuyer();
        bool EditBuyer(Buyer buyer);
        bool DeleteBuyer(int id);
    }
}
