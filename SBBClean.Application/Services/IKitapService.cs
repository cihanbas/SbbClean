using SBBClean.Application.DTOs;

namespace SBBClean.Application.Services;

public interface IKitapService
{
    Task<List<KitapDto>> GetAllAsync();
    Task<KitapDto?> GetByIdAsync(int id);
    Task<KitapDto> CreateAsync(KitapCreateDto dto);
}
