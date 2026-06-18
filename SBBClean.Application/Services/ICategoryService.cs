using SBBClean.Application.DTOs;

namespace SBBClean.Application.Services;

public interface ICategoryService
{
    public Task<List<CategoryDto>> GetAllAsync();
    public Task<CategoryDto?> GetByIdAsync(int id);
    public Task<CategoryDto?> CreateAsync(CategoryDto category);
}