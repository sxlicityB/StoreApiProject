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

        //POST endpoint
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDTO ProductCreate)
        {
            if (ProductCreate == null)
                BadRequest("Product data is null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var NewProduct = _mapper.Map<Product>(ProductCreate);

            if (!_productRepository.CreateProduct(NewProduct))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created product");
        }

        //PUT endpoint
        [HttpPut("{ProductId}")]
        public IActionResult UpdateProduct(int ProductId, [FromBody] UpdateProductDTO ProductUpdateDto)
        {
            if (ProductUpdateDto == null || ProductId != ProductUpdateDto.ProductId)
                return BadRequest("Invalid data.");

            var UpdatedProduct = _mapper.Map<Product>(ProductUpdateDto);

            if (!_productRepository.EditProduct(UpdatedProduct))
            {
                ModelState.AddModelError("", "Something went wrong while updating the buyer");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //Delete endpoint
        [HttpDelete]
        public IActionResult DeleteProduct(int ProductId)
        {
            var DeletedProduct = _productRepository.DeleteProduct(ProductId);
            return Ok(DeletedProduct);
        }
    }
}
