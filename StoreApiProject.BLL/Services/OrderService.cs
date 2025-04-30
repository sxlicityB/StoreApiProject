using StoreApiProject.DAL.Interfaces;
using StoreApiProject.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApiProject.DAL.Repository;
using StoreApiProject.Domain.Models;

namespace StoreApiProject.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<ICollection<Order>> GetOrdersAsync()
    {
        return await _orderRepository.GetOrdersAsync();
    }

    public async Task<Order> GetOrderAsync(int id)
    {
        return await _orderRepository.GetOrderAsync(id);
    }

    public async Task<bool> CreateOrderAsync(Order order)
    {
        return await _orderRepository.CreateOrderAsync(order);
    }

    public async Task<bool> UpdateOrderAsync()
    {
        return await _orderRepository.UpdateOrderAsync();
    }

    public async Task<bool> EditOrderAsync(Order order)
    {
        return await _orderRepository.EditOrderAsync(order);
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        return await _orderRepository.DeleteOrderAsync(id);
    }

    public async Task<bool> ValidateAndProcessOrderAsync(Order order)
    {
        foreach (var orderProduct in order.OrderProducts)
        {
            var product = await _productRepository.GetProductAsync(orderProduct.ProductId);
            if (product != null)
            {
                orderProduct.Product = product;
                orderProduct.UnitPrice = product.Price;
            }
            else
                throw new InvalidOperationException($"Product with ID {orderProduct.ProductId} not found.");
        }
        return await CreateOrderAsync(order);
    }
}
