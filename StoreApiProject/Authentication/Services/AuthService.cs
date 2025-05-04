using Microsoft.IdentityModel.Tokens;
using StoreApiProject.Authentication.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreApiProject.Authentication.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> AuthenticateAsync(string username, string password)
    {
        // Simulated lookup (replace with real DB logic)
        if (username != "admin" || password != "password123")
            return null;



        var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
        new Claim(ClaimTypes.Name, username),
        new Claim(ClaimTypes.Role, "Admin")
    }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
