using CleanArchTemplate.Application.DTOs.Auth;

namespace CleanArchTemplate.Application.Interfaces.Auth;

public interface IAuthService
{
    Task<AuthResultDto?> Authenticate(string username, string password);
}