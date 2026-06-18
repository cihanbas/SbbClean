using SBBClean.Domain.Entities;

namespace SBBClean.Application.Interfaces;

public interface IYazarRepository
{
     Task<List<Yazar>> GetAllAsync();
     Task<Yazar> GetByIdAsync(int id);
     Task  CreateAsync(Yazar yazar);
}