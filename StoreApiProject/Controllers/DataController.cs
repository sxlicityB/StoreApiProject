using Microsoft.AspNetCore.Mvc;
using StoreApiProject.BLL.Interfaces;
namespace StoreApiProject.Controllers;

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
    public async Task<IActionResult> GenerateMockData(int CycleCount)
    {
        for (int i = 0; i < CycleCount; i++)
        {
            await _dataService.GenerateDataAsync();
        }
        return Ok(new { message = "Mock data generated successfully!" });
    }

    [HttpPost("resetDB")]
    public async Task<IActionResult> ResetDatabase()
    {
        try
        {
            await _dataService.ResetDatabaseAsync();
            return Ok("Database was sucessfully reset!");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
