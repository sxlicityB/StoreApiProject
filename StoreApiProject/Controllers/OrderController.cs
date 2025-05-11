using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.BLL.Interfaces;
using AutoMapper;
using StoreApiProject.DTOs;
using System.Reflection.Metadata.Ecma335;
using StoreApiProject.Domain.Enums;

namespace StoreApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public OrderController(IOrderService OrderService, IBuyerService BuyerService, IProductService ProductService, IMapper mapper)
    {
        this._orderService = OrderService;
        this._productService = ProductService;
        _mapper = mapper;
    }

    // Get endpoints

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderService.GetOrdersAsync();
        var mappedOrders = _mapper.Map<List<GetOrderDTO>>(orders);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(mappedOrders);
    }

    //Get by id endpoints

    [HttpGet("{OrderId}")]
    public async Task<IActionResult> GetOrder(int OrderId)
    {
        var order = await _orderService.GetOrderAsync(OrderId);
        var mappedOrder = _mapper.Map<GetOrderDTO>(order);
        return Ok(mappedOrder);
    }

    //POST endpoints

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO OrderCreate)
    {

        var newOrder = _mapper.Map<Order>(OrderCreate);
        newOrder.Status = OrderStatus.Pending;

        if (!await _orderService.ValidateAndProcessOrderAsync(newOrder))
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

        if (!await _orderService.EditOrderAsync(UpdatedOrder))
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
        var DeletedOrder = await _orderService.DeleteOrderAsync(OrderId);
        return Ok(DeletedOrder);
    }
    
    

}
