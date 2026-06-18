using SBBClean.Domain.Entities;

namespace  SBBClean.Application.Interfaces;

public interface ICategoryRepository
{
    Task<List<Kategori>> GetAllAsync();
    Task<Kategori?> GetByIdAsync(int id);
    Task AddAsync(Kategori kategori);
    Task UpdateAsync(Kategori kategori);
    Task DeleteAsync(int id);
}