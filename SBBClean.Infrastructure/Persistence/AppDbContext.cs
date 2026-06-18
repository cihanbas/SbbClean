
using Microsoft.EntityFrameworkCore;
using SBBClean.Domain.Entities;

namespace SBBClean.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
    }
    public DbSet<Urun> Urunler { get; set; }
    public DbSet<Kategori> Kategoriler { get; set; }
    public DbSet<Yazar> Yazarler { get; set; }
    public DbSet<Kitap> Kitaplar { get; set; }
}