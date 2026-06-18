using SBBClean.Application.DTOs;
namespace SBBClean.Application.Services;

public interface IYazarService
{
    Task<List<YazarDto>> GetAllAsync();
    Task<YazarDto> GetByIdAsync(int id);
    Task<YazarDto> CreateAsync(YazarDto urun);
}