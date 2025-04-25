using StoreApiProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.DAL.Projections;

public class OrderProductProjection
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; } // navigational
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; } // to save historivcal prices of the products
}
