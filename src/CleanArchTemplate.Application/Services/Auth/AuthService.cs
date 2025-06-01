using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CleanArchTemplate.Application.DTOs.Auth;
using CleanArchTemplate.Application.Interfaces.Auth;
using CleanArchTemplate.Domain.Entities.Auth;
using CleanArchTemplate.Domain.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchTemplate.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly JwtSettings _jwtSettings;
    private readonly List<User> _users = new()
    {
        new User { Id = new Guid(), Username = "admin", Password = "admin" }
    };

    public AuthService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResultDto?> Authenticate(string username, string password)
    {
        var user = _users.SingleOrDefault(u => u.Username == username && u.Password == password);

        if (user == null) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new AuthResultDto
        {
            Token = tokenString,
            ExpiresIn = _jwtSettings.ExpiryInMinutes * 60
        };
    }
}