using Microsoft.AspNetCore.Mvc;
using Store_Api_Proj.Interfaces;
namespace Store_Api_Proj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MockDataController : ControllerBase
    {
        private readonly IDataService _dataService;
        
        public MockDataController(IDataService dataService)
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
    }
}
