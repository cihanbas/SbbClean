using SBBClean.Domain.Entities;

namespace  SBBClean.Application.Interfaces;

public interface IUrunRepository
{
    Task<List<Urun>> GetAllAsync();
    Task<Urun?> GetByIdAsync(int id);
    Task AddAsync(Urun urun);
    Task UpdateAsync(Urun urun);
    Task DeleteAsync(int id);
}