using AutoMapper;
using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Services;

public class UrunService(IUrunRepository repo, IUnitOfWorks unitOfWorks, IMapper mapper) : IUrunService
{
    public async Task<List<UrunDto>> GetAllAsync()
    {
        var urunler = await repo.GetAllAsync();
        return mapper.Map<List<UrunDto>>(urunler);
    }

    public async Task<UrunDto> GetByIdAsync(int id)
    {
        var urun = await repo.GetByIdAsync(id);
        if (urun == null) throw new KeyNotFoundException();
        return mapper.Map<UrunDto>(urun);
    }

    public async Task<UrunDto> CreateAsync(UrunCreateDto dto)
    {
        var urun = mapper.Map<Urun>(dto);
        await repo.AddAsync(urun);
        await unitOfWorks.SaveChangesAsync();
        return mapper.Map<UrunDto>(urun);
    }
}
