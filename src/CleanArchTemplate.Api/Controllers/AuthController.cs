using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using CleanArchTemplate.Application.Interfaces.Auth;

namespace CleanArchTemplate.Api.Controllers;

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
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await _authService.Authenticate(request.Email, request.Password);

        if (result == null) return Unauthorized();

        return Ok(result);
    }
}