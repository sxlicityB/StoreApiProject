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
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProduct ProductRepository, IMapper mapper)
        {
            this._productRepository = ProductRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepository.GetProducts();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }

        [HttpGet("{ProductId}")]
        public IActionResult GetProduct(int ProductId)
        {
            var product = _productRepository.GetProduct(ProductId);
            return Ok(product);
        }
    }
}
