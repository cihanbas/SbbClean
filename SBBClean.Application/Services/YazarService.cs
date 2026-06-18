using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Services;

public class YazarService(IYazarRepository repo, IUnitOfWorks unitOfWorks):IYazarService
{
    public async Task<List<YazarDto>> GetAllAsync()
    {
      var all=  await repo.GetAllAsync();
      return all.Select(y=> new YazarDto
      {
          Id =  y.Id,
            Ad = y.Ad,
            Soyad =  y.Soyad,
            Kitaplar = ( y.Kitaplar?? new()).Select(k=> new KitapDto
            {
                Id = k.Id,
                Title = k.Title,
                Date = k.Date,
                YazarId =  k.YazarId
                
            }).ToList()
      }).ToList();
    }

    public Task<YazarDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<YazarDto> CreateAsync(YazarDto yazar)
    {
        var _yazar = new Yazar { Ad = yazar.Ad, Soyad = yazar.Soyad };
        await repo.CreateAsync(_yazar);
        await unitOfWorks.SaveChangesAsync();
        return  new YazarDto { Ad = yazar.Ad,Soyad =  yazar.Soyad, Id = _yazar.Id };
    }
}