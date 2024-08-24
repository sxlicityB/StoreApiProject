using Store_Api_Proj.Models;

namespace Store_Api_Proj.Interfaces
{
    public interface IBuyer
    {
        ICollection<Buyer> GetBuyers();
        Buyer GetBuyer(int id);
    }
}
