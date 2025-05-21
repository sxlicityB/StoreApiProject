using StoreApiProject.DAL.Projections;
using StoreApiProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.BLL.Models;

public class OrderModel
{
    public int OrderId { get; set; }
    public List<OrderProductModel> OrderProducts { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalPrice => OrderProducts.Sum(p => p.UnitPrice * p.Quantity);
}
