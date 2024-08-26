using Microsoft.AspNetCore.Mvc;
using Store_Api_Proj.Data;
using Store_Api_Proj.Models;
using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.Interfaces;
using Store_Api_Proj.Repository;
using AutoMapper;
using Store_Api_Proj.DTOs;

namespace Store_Api_Proj.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class APIController : ControllerBase
    {
        private readonly IOrder _orderRepository;
        private readonly IBuyer _buyerRepository;
        private readonly IProduct _productRepository;
        private readonly IMapper _mapper;

        public APIController(IOrder OrderRepository, IBuyer BuyerRepository, IProduct ProductRepository, IMapper mapper)
        {
            this._orderRepository = OrderRepository;
            this._buyerRepository = BuyerRepository;
            this._productRepository = ProductRepository;
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

        [HttpGet]
        public IActionResult GetBuyers()
        {
            var buyers = _buyerRepository.GetBuyers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(buyers);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }

        //Get by id endpoints

        [HttpGet("{OrderId}")]
        public IActionResult GetOrder(int OrderId)
        {
            var order = _mapper.Map<GetOrderDTO>(_orderRepository.GetOrder(OrderId));
            return Ok(order);
        }

        [HttpGet("{BuyerId}")]
        public IActionResult GetBuyer(int buyerId)
        {
            var buyer = _buyerRepository.GetBuyer(buyerId);
            return Ok(buyer);
        }

        [HttpGet("{ProductId}")]
        public IActionResult GetProduct(int ProductId)
        {
            var product = _productRepository.GetProduct(ProductId);
            return Ok(product);
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
            NewOrder.TotalPrice = NewOrder.CalculateTotalPrice();

            if (!_orderRepository.CreateOrder(NewOrder))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created order");
        }


    }
}
