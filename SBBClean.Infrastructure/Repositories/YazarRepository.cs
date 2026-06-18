using Microsoft.EntityFrameworkCore;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Infrastructure.Repositories;

public class YazarRepository(AppDbContext context):IYazarRepository
{
    public async Task<List<Yazar>> GetAllAsync()
    {
        return await context.Yazarler.Include(y => y.Kitaplar).ToListAsync();
    }

    public async Task<Yazar> GetByIdAsync(int id)
    {
         var yazar =  await context.Yazarler.FirstOrDefaultAsync(y => y.Id == id);
         if (yazar == null)
         {
             throw new ApplicationException($"Yazar with id {id} not found");
         }
return yazar;
    }

    public async Task CreateAsync(Yazar yazar)
    {
         await context.Yazarler.AddAsync(yazar);
    }
}