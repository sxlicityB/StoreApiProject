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
        public IActionResult GetBuyers()
        {
            var buyers = _buyerRepository.GetBuyers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(buyers);
        }

        [HttpGet("{BuyerId}")]
        public IActionResult GetBuyer(int buyerId)
        {
            var buyer = _buyerRepository.GetBuyer(buyerId);
            return Ok(buyer);
        }

        //POST endpoint
        [HttpPost]
        public IActionResult CreateBuyer([FromBody] CreateBuyerDTO BuyerCreate)
        {
            if (BuyerCreate == null)
                BadRequest("Buyer data is null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var NewBuyer = _mapper.Map<Buyer>(BuyerCreate);

            if (!_buyerRepository.CreateBuyer(NewBuyer))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created buyer");
        }
    }
}
