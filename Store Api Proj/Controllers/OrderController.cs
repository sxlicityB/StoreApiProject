using Microsoft.AspNetCore.Mvc;
using Store_Api_Proj.Data;
using Store_Api_Proj.Models;
using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.Interfaces;
using Store_Api_Proj.Repository;
using AutoMapper;
using Store_Api_Proj.DTOs;
using System.Reflection.Metadata.Ecma335;

namespace Store_Api_Proj.Controllers
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
            if (OrderCreate == null)
                BadRequest("Order data is null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var NewOrder = _mapper.Map<Order>(OrderCreate);
            NewOrder.Status = Order.OrderStatus.Pending;

            foreach (var orderProduct in NewOrder.OrderProducts)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == orderProduct.ProductId);
                if (product != null)
                {
                    orderProduct.Product = product;
                }
            }
            

            

            if (!_orderRepository.CreateOrder(NewOrder))
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
            if (OrderUpdateDto == null || OrderId != OrderUpdateDto.OrderId)
                return BadRequest("Invalid data.");

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
