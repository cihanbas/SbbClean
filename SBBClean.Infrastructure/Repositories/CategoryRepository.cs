using Microsoft.EntityFrameworkCore;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context):ICategoryRepository
{
    public async Task<List<Kategori>> GetAllAsync()
    {
        return await context.Kategoriler.ToListAsync();
    }

    public async Task<Kategori?> GetByIdAsync(int id)
    {
        return  await context.Kategoriler.FirstOrDefaultAsync(k=>k.Id == id);
    }

    public async Task AddAsync(Kategori kategori)
    {
        await context.Kategoriler.AddAsync(kategori);
    }

    public Task UpdateAsync(Kategori kategori)
    {
        try
        {
            context.Kategoriler.Update(kategori);
            return Task.CompletedTask;
        }
        catch (Exception exception)
        {
            return Task.FromException(exception);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var k = await GetByIdAsync(id);
        if (k != null)
        {
            context.Kategoriler.Remove(k);    
        }
        

    }
}