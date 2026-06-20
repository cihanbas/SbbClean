using AutoMapper;
using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Services;

public class YazarService(IYazarRepository repo, IUnitOfWorks unitOfWorks, IMapper mapper) : IYazarService
{
    public async Task<List<YazarDto>> GetAllAsync()
    {
        var yazarlar = await repo.GetAllAsync();
        return mapper.Map<List<YazarDto>>(yazarlar);
    }

    public async Task<YazarDto?> GetByIdAsync(int id)
    {
        var yazar = await repo.GetByIdAsync(id);
        return mapper.Map<YazarDto?>(yazar);
    }

    public async Task<YazarDto> CreateAsync(YazarDto dto)
    {
        var yazar = mapper.Map<Yazar>(dto);
        await repo.CreateAsync(yazar);
        await unitOfWorks.SaveChangesAsync();
        return mapper.Map<YazarDto>(yazar);
    }
}
