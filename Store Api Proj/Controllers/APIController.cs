using Microsoft.AspNetCore.Mvc;
using Store_Api_Proj.Data;
using Store_Api_Proj.Models;
using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.Interfaces;

namespace Store_Api_Proj.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class APIController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IOrder _orderRepository;


        // Get endpoints
        public APIController(IOrder OrderRepository) {
            this._orderRepository = OrderRepository;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderRepository.GetOrders();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }
        /*public ActionResult Index()
        {




            [HttpGet]
            public IActionResult GetOrders()
            {
                return Ok(_context.Orders.ToList());
            }

            [HttpGet]
            public IActionResult GetProducts()
            {
                return Ok(_context.Products.ToList());
            }

            [HttpGet]
            public IActionResult GetBuyers()
            {
                return Ok(_context.Buyers.ToList());
            }


            // Get by id endpoints
            [HttpGet("{id}")]
            public IActionResult GetOrderById(int id) {
                var order = _context.Orders.Find(id);

                if (order == null)
                    return NotFound();

                return Ok(order);
            }

            // Post endpoints
            [HttpPost]
            public IActionResult AddOrder(Order order) {
                _context.Orders.Add(order);
                _context.SaveChanges();

                return Ok();
            }

            [HttpPost]
            public IActionResult AddProduct(Product product) {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(_context.Products);
            }

            // Delete endpoints
            [HttpDelete]
            public IActionResult DeleteOrder(int id)
            {
                var order = _context.Orders.Find(id);
                if(order == null)
                {
                    return NotFound();
                }
                _context.Orders.Remove(order);
                _context.SaveChanges();

                return Ok(_context.Orders);
            }*/

    
    }
}
