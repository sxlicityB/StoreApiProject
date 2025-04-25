using StoreApiProject.Domain.Enums;
using StoreApiProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApiProject.DAL.Projections;

namespace StoreApiProject.DAL.Projections;

public class OrderProjection
{
    public int OrderId { get; set; }
    public List<OrderProductProjection> OrderProducts { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalPrice => OrderProducts.Sum(p => p.UnitPrice * p.Quantity);
}
