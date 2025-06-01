namespace CleanArchTemplate.Application.DTOs.Auth;

public class AuthResultDto
{
    public string Token { get; set; }
    public int ExpiresIn { get; set; }
}