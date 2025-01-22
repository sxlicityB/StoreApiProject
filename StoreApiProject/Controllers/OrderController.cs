using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Data;
using StoreApiProject.Models;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.Interfaces;
using StoreApiProject.Repository;
using AutoMapper;
using StoreApiProject.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace StoreApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IProduct _productRepository;

        public OrderController(AppDbContext context, IOrder OrderRepository, IBuyer BuyerRepository, IProduct ProductRepository, IMapper mapper)
        {
            this._orderRepository = OrderRepository;
            this._productRepository = ProductRepository;
            _mapper = mapper;
        }

        // Get endpoints

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderRepository.GetOrders();
            var mappedOrders = _mapper.Map<List<GetOrderDTO>>(orders);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mappedOrders);
        }

        //Get by id endpoints

        [HttpGet("{OrderId}")]
        public async Task<IActionResult> GetOrder(int OrderId)
        {
            var order = await _orderRepository.GetOrder(OrderId);
            var mappedOrder = _mapper.Map<GetOrderDTO>(order);
            return Ok(mappedOrder);
        }

        //POST endpoints

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO OrderCreate)
        {

            var newOrder = _mapper.Map<Order>(OrderCreate);
            newOrder.Status = Order.OrderStatus.Pending;

            foreach (var orderProduct in newOrder.OrderProducts)
            {
                var product = await _productRepository.GetProduct(orderProduct.ProductId);
                if (product != null)
                    orderProduct.Product = product;
                else
                    throw new InvalidOperationException($"Product with ID {orderProduct.ProductId} not found.");

            }

            if (!await _orderRepository.CreateOrder(newOrder))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created order");
        }


        //PUT endpoints
        [HttpPut("{OrderId}")]
        public async Task<IActionResult> UpdateOrder(int OrderId, [FromBody] UpdateOrderDTO OrderUpdateDto) 
        {
            if (OrderId != OrderUpdateDto.OrderId)
                return BadRequest("Order IDs don't match");

            var UpdatedOrder = _mapper.Map<Order>(OrderUpdateDto);

            if (!await _orderRepository.EditOrder(UpdatedOrder))
            {
                ModelState.AddModelError("", "Something went wrong while updating the order");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //Delete endpoint
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int OrderId)
        {
            var DeletedOrder = await _orderRepository.DeleteOrder(OrderId);
            return Ok(DeletedOrder);
        }
        
        

    }
}
