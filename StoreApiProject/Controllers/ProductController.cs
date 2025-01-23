using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Data;
using StoreApiProject.Models;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.Interfaces;
using StoreApiProject.Repository;
using AutoMapper;
using StoreApiProject.DTOs;

namespace StoreApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);
        }

        [HttpGet("{ProductId}")]
        public async Task<IActionResult> GetProduct(int ProductId)
        {
            var product = await _productRepository.GetProduct(ProductId);
            return Ok(product);
        }

        //POST endpoint
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO ProductCreate)
        {
            var NewProduct = _mapper.Map<Product>(ProductCreate);

            if (!await _productRepository.CreateProduct(NewProduct))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created product");
        }

        //PUT endpoint
        [HttpPut("{ProductId}")]
        public async Task<IActionResult> UpdateProduct(int ProductId, [FromBody] UpdateProductDTO ProductUpdateDto)
        {
            if (ProductUpdateDto == null || ProductId != ProductUpdateDto.ProductId)
                return BadRequest("Invalid data.");

            var UpdatedProduct = _mapper.Map<Product>(ProductUpdateDto);

            if (!await _productRepository.EditProduct(UpdatedProduct))
            {
                ModelState.AddModelError("", "Something went wrong while updating the buyer");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //Delete endpoint
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            var DeletedProduct = await _productRepository.DeleteProduct(ProductId);
            return Ok(DeletedProduct);
        }
    }
}
