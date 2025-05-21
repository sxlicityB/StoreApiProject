using StoreApiProject.BLL.Models;
using StoreApiProject.DAL.Projections;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.BLL.ManualMapster;

public static class BuyerMapper
{
    public static BuyerWithOrdersModel ToModel(BuyerWithOrdersProjection projection)
    {
        return new BuyerWithOrdersModel
        {
            BuyerId = projection.BuyerId,
            Name = projection.Name,
            Orders = projection.Orders.Select(o => new OrderModel {
                OrderId = o.OrderId,
                Status = o.Status,
                OrderProducts = o.OrderProducts.Select(op => new OrderProductModel                //load up OrderProduct as projection correctly
                {
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    Product = op.Product,       //this will load up OrderProducts as well but I think complicating repository just for Null to not show up is exscessive
                    Quantity = op.Quantity,
                    UnitPrice = op.UnitPrice
                }).ToList()
            }).ToList()
        };
    }   
}
