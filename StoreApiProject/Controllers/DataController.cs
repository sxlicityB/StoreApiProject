using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Interfaces;
namespace StoreApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;
        
        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public IActionResult GenerateMockData(int CycleCount)
        {
            for (int i = 0; i < CycleCount; i++)
            {
                _dataService.GenerateData();
            }
            return Ok(new { message = "Mock data generated successfully!" });
        }

        [HttpPost("resetDB")]
        public IActionResult ResetDatabase()
        {
            try
            {
                _dataService.ResetDatabase();
                return Ok("Database was sucessfully reset!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
