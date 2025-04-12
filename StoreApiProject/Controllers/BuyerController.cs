using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.BLL.Interfaces;
using AutoMapper;
using StoreApiProject.DTOs;
using StoreApiProject.DAL.Projections;

namespace StoreApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        private readonly IMapper _mapper;
        public BuyerController(IBuyerService BuyerService, IMapper mapper)
        {
            this._buyerService = BuyerService;
            _mapper = mapper;
        }

        [HttpGet("Get all buyers")]
        public async Task<IActionResult> GetBuyers()
        {
            var buyers = await _buyerService.GetBuyersAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(buyers);
        }

        [HttpGet("{BuyerId}")]
        public async Task<IActionResult> GetBuyer(int BuyerId)
        {
            var buyer = await _buyerService.GetBuyerAsync(BuyerId);
            return Ok(buyer);
        }

        [HttpGet("Get buyers with orders")]
        public async Task<List<BuyerWithOrdersProjection>> GetBuyerWithOrders()
        {
            var buyers = await _buyerService.GetBuyerWithOrdersAsync();
            return buyers;
        }

        //POST endpoint
        [HttpPost]
        public async Task<IActionResult> CreateBuyer([FromBody] CreateBuyerDTO BuyerCreate)
        {

            var NewBuyer = _mapper.Map<Buyer>(BuyerCreate);

            if (!await _buyerService.CreateBuyerAsync(NewBuyer))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created buyer");
        }

        //PUT endpoint
        [HttpPut("{BuyerId}")]
        public async Task<IActionResult> UpdateBuyer(int BuyerId, [FromBody] UpdateBuyerDTO BuyerUpdateDto)
        {
            if (BuyerId != BuyerUpdateDto.BuyerId)
                return BadRequest("Buyer IDs don't match");

            var UpdatedBuyer = _mapper.Map<Buyer>(BuyerUpdateDto);

            if (!await _buyerService.EditBuyerAsync(UpdatedBuyer))
            {
                ModelState.AddModelError("", "Something went wrong while updating the buyer");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        //Delete endpoint
        [HttpDelete]
        public async Task<IActionResult> DeleteBuyer(int BuyerId)
        {
            var DeletedBuyer = await _buyerService.DeleteBuyerAsync(BuyerId);
            return Ok(DeletedBuyer);
        }
    }
}
