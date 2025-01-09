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

        public OrderController(AppDbContext context, IOrder OrderRepository, IBuyer BuyerRepository, IProduct ProductRepository, IMapper mapper)
        {
            this._orderRepository = OrderRepository;
            _mapper = mapper;
        }

        // Get endpoints

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _mapper.Map<List<GetOrderDTO>>(_orderRepository.GetOrders());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }

        //Get by id endpoints

        [HttpGet("{OrderId}")]
        public IActionResult GetOrder(int OrderId)
        {
            var order = _mapper.Map<GetOrderDTO>(_orderRepository.GetOrder(OrderId));
            return Ok(order);
        }

        //POST endpoints

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDTO OrderCreate)
        {

            var newOrder = _mapper.Map<Order>(OrderCreate);
            newOrder.Status = Order.OrderStatus.Pending;

            foreach (var orderProduct in newOrder.OrderProducts)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == orderProduct.ProductId);
                if (product != null)
                {
                    orderProduct.Product = product;
                }
            }

            if (!_orderRepository.CreateOrder(newOrder))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created order");
        }


        //PUT endpoints
        [HttpPut("{OrderId}")]
        public IActionResult UpdateOrder(int OrderId, [FromBody] UpdateOrderDTO OrderUpdateDto) 
        {
            if (OrderId != OrderUpdateDto.OrderId)
                return BadRequest("Order IDs don't match");

            var UpdatedOrder = _mapper.Map<Order>(OrderUpdateDto);

            if (!_orderRepository.EditOrder(UpdatedOrder))
            {
                ModelState.AddModelError("", "Something went wrong while updating the order");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //Delete endpoint
        [HttpDelete]
        public IActionResult DeleteOrder(int OrderId)
        {
            var DeletedOrder = _orderRepository.DeleteOrder(OrderId);
            return Ok(DeletedOrder);
        }
        
        

    }
}
