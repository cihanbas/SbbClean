using Microsoft.EntityFrameworkCore;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;
using SBBClean.Infrastructure.Persistence;

namespace SBBClean.Infrastructure.Repositories;

public class KitapRepository : IKitapRepository
{
    private readonly AppDbContext _context;

    public KitapRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Kitap>> GetAllAsync()
        => await _context.Kitaplar.Include(k => k.Yazar).ToListAsync();

    public async Task<Kitap?> GetByIdAsync(int id)
        => await _context.Kitaplar.Include(k => k.Yazar).FirstOrDefaultAsync(k => k.Id == id);

    public async Task AddAsync(Kitap kitap)
        => await _context.Kitaplar.AddAsync(kitap);
}
