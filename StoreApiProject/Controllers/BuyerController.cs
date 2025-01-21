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
    public class BuyerController : ControllerBase
    {
        private readonly IBuyer _buyerRepository;
        private readonly IMapper _mapper;
        public BuyerController(IBuyer BuyerRepository, IMapper mapper)
        {
            this._buyerRepository = BuyerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuyers()
        {
            var buyers = await _buyerRepository.GetBuyers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(buyers);
        }

        [HttpGet("{BuyerId}")]
        public async Task<IActionResult> GetBuyer(int BuyerId)
        {
            var buyer = await _buyerRepository.GetBuyer(BuyerId);
            return Ok(buyer);
        }

        //POST endpoint
        [HttpPost]
        public async Task<IActionResult> CreateBuyer([FromBody] CreateBuyerDTO BuyerCreate)
        {

            var NewBuyer = _mapper.Map<Buyer>(BuyerCreate);

            if (!await _buyerRepository.CreateBuyer(NewBuyer))
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

            if (!await _buyerRepository.EditBuyer(UpdatedBuyer))
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
            var DeletedBuyer = await _buyerRepository.DeleteBuyer(BuyerId);
            return Ok(DeletedBuyer);
        }
    }
}
