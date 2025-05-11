using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.BLL.Interfaces;
namespace StoreApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppUserController : ControllerBase
{
    private readonly IAppUserService _appUserService;
    public AppUserController(IAppUserService appUserService)
    {

    _appUserService = appUserService;
    }
    [HttpGet("Get_All_Users")]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(await _appUserService.GetUsersAsync());
    }
}
