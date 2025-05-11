using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.BLL.Interfaces;
using AutoMapper;
using StoreApiProject.DTOs;

namespace StoreApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    public ProductController(IProductService ProductService, IMapper mapper)
    {
        this._productService = ProductService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetProductsAsync();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(products);
    }

    [HttpGet("{ProductId}")]
    public async Task<IActionResult> GetProduct(int ProductId)
    {
        var product = await _productService.GetProductAsync(ProductId);
        return Ok(product);
    }

    //POST endpoint
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO ProductCreate)
    {
        var NewProduct = _mapper.Map<Product>(ProductCreate);

        if (!await _productService.CreateProductAsync(NewProduct))
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

        if (!await _productService.EditProductAsync(UpdatedProduct))
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
        var DeletedProduct = await _productService.DeleteProductAsync(ProductId);
        return Ok(DeletedProduct);
    }
}
