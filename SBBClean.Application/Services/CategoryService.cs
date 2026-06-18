using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Services;

public class CategoryService(ICategoryRepository repo, IUnitOfWorks unitOfWork) : ICategoryService
{
    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var all = await repo.GetAllAsync();
        return all.Select(k => new CategoryDto { Ad = k.Ad, Id = k.Id }).ToList();
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var k = await repo.GetByIdAsync(id);
        if (k == null)
        {
            return null;
        }

        return new CategoryDto { Ad = k.Ad, Id = k.Id };
    }

    public async Task<CategoryDto?> CreateAsync(CategoryDto category)
    {
        var kategori = new Kategori { Ad = category.Ad, Id = category.Id };
        await repo.AddAsync(kategori);
        await unitOfWork.SaveChangesAsync();
        return new CategoryDto { Ad = kategori.Ad, Id = kategori.Id };
    }
}