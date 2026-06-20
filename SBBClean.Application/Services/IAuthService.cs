using SBBClean.Application.DTOs;

namespace SBBClean.Application.Services;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
    Task<LoginResponseDto?> RegisterAsync(RegisterRequestDto request);
    Task<LoginResponseDto?> UpdateProfileAsync(string username, UpdateProfileDto request);
}
