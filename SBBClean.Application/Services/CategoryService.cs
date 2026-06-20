using AutoMapper;
using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Services;

public class CategoryService(ICategoryRepository repo, IUnitOfWorks unitOfWork, IMapper mapper) : ICategoryService
{
    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var kategoriler = await repo.GetAllAsync();
        return mapper.Map<List<CategoryDto>>(kategoriler);
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var kategori = await repo.GetByIdAsync(id);
        return mapper.Map<CategoryDto?>(kategori);
    }

    public async Task<CategoryDto?> CreateAsync(CategoryDto dto)
    {
        var kategori = mapper.Map<Kategori>(dto);
        await repo.AddAsync(kategori);
        await unitOfWork.SaveChangesAsync();
        return mapper.Map<CategoryDto>(kategori);
    }
}
