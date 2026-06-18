using SBBClean.Domain.Entities;

namespace SBBClean.Application.Interfaces;

public interface IKitapRepository
{
    Task<List<Kitap>> GetAllAsync();
    Task<Kitap?> GetByIdAsync(int id);
    Task AddAsync(Kitap kitap);
}
