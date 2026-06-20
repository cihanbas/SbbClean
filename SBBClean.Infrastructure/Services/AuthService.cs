using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Application.Services;
using SBBClean.Domain.Entities;

namespace SBBClean.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWorks _unitOfWork;

    public AuthService(AppDbContext context, IConfiguration configuration, IUnitOfWorks unitOfWork)
    {
        _context = context;
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }

    public async Task<LoginResponseDto?> RegisterAsync(RegisterRequestDto request)
    {
        var exists = await _context.Users.AnyAsync(u => u.Username == request.Username);
        if (exists)
        {
            Log.Warning("Kayıt başarısız - kullanıcı adı zaten var: {Username}", request.Username);
            return null;
        }

        var user = new AppUser
        {
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role
        };

        _context.Users.Add(user);
        await _unitOfWork.SaveChangesAsync();

        var token = GenerateToken(user.Username, user.Role);
        return new LoginResponseDto
        {
            Token = token,
            Username = user.Username,
            Role = user.Role
        };
    }

 

    public async Task<LoginResponseDto?> UpdateProfileAsync(string username, UpdateProfileDto request)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null) return null;

        if (!BCrypt.Net.BCrypt.Verify(request.oldPassword, user.PasswordHash)) return null;

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.newPassword);
        _context.Users.Update(user);
        await _unitOfWork.SaveChangesAsync();

        var token = GenerateToken(user.Username, user.Role);
        return new LoginResponseDto { Token = token, Username = user.Username, Role = user.Role };
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            Log.Warning("Giriş başarısız - hatalı kullanıcı adı veya şifre: {Username}", request.Username);
            return null;
        }

        var token = GenerateToken(user.Username, user.Role);

        return new LoginResponseDto
        {
            Token = token,
            Username = user.Username,
            Role = user.Role
        };
    }

    private string GenerateToken(string username, string role)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
