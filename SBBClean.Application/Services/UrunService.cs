using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Services;

public class UrunService(IUrunRepository repo, IUnitOfWorks unitOfWorks) : IUrunService
{
    public async Task<List<UrunDto>> GetAllAsync()
    {
        var urunler = await repo.GetAllAsync();
        return urunler.Select(u => new UrunDto { Id = u.Id, Ad = u.Ad, Fiyat = u.Fiyat,Kategori = u.Kategori==null?null: new CategoryDto{Ad = u.Kategori.Ad,Id = u.Kategori.Id}}).ToList();
    }

    public async Task<UrunDto> GetByIdAsync(int id)
    {
        var urun = await repo.GetByIdAsync(id);
        if (urun == null)
        {
            throw new KeyNotFoundException();
        }
        
        return new UrunDto { Ad = urun.Ad, Fiyat = urun.Fiyat, Kategori = urun.Kategori != null && urun.Kategori.Id != 0?new CategoryDto{Ad =  urun.Kategori.Ad,Id = urun.Kategori.Id}:null };
    }

    public async Task<UrunDto> CreateAsync(UrunCreateDto urun)
    {
        var u = new Urun { Ad = urun.Ad, Fiyat = urun.Fiyat, StokAdedi = urun.StokAdedi,KategoriId = urun.kategoriId};
        await repo.AddAsync(u);
        await unitOfWorks.SaveChangesAsync();
        return new UrunDto
            { Id = u.Id, Ad = u.Ad, Fiyat = u.Fiyat };
    }
}