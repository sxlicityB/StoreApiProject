using StoreApiProject.DAL.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.BLL.Models;

public class BuyerWithOrdersModel
{
    public int BuyerId { get; set; }
    public string? Name { get; set; }
    public List<OrderModel> Orders { get; set; }
}
