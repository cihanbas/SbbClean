using SBBClean.Application.DTOs;
namespace SBBClean.Application.Services;

public interface IUrunService
{
    Task<List<UrunDto>> GetAllAsync();
    Task<UrunDto> GetByIdAsync(int id);
    Task<UrunDto> CreateAsync(UrunCreateDto urun);
}