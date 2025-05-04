using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Authentication.Interfaces;
using StoreApiProject.Authentication.Services;
using StoreApiProject.DTOs;

namespace StoreApiProject.Controllersp;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
    {
        var token = await _authService.AuthenticateAsync(request.Username, request.Password);

        if (token == null)
            return Unauthorized();

        return Ok(new LoginResponseDTO { Token = token });
    }
}
