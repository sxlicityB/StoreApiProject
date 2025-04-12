using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.DAL.Projections;

public class BuyerWithOrdersProjection
{
    public int BuyerId { get; set; }
    public string? Name { get; set; }
    public List<OrderProjection> Orders { get; set; }
}
