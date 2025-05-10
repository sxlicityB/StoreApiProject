using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using StoreApiProject.Authentication.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreApiProject.Authentication.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly JwtService _jwtService;

    public AuthService(IConfiguration configuration, JwtService jwtService)
    {
        _configuration = configuration;
        _jwtService = jwtService;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        // Simulated lookup (replace with real DB logic)
        if (username != "admin" || password != "password123")
            return null;

        return await _jwtService.GenerateTokenAsync(username);
    }
}
