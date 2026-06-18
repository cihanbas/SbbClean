using Microsoft.EntityFrameworkCore;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Infrastructure.Repositories;

public class UrunRepository(AppDbContext context) : IUrunRepository
{
    private readonly AppDbContext _context = context;

    public async Task<List<Urun>> GetAllAsync()
    {
        return await _context.Urunler.Include(u=>u.Kategori).ToListAsync();
    }

    public async Task<Urun?> GetByIdAsync(int id)
    {
        return await _context.Urunler.Include(u=>u.Kategori).FirstOrDefaultAsync(u=>u.Id == id);
    }

    public async Task AddAsync(Urun urun)
    {
         await _context.Urunler.AddAsync(urun);
      
    }

    public async Task UpdateAsync(Urun urun)
    {
        _context.Urunler.Update(urun); 

    }

    public async  Task DeleteAsync(int id)
    {
        var urun = await _context.Urunler.FindAsync(id);
        if (urun != null)
        {
            _context.Urunler.Remove(urun);
         
        }
        
    }
}