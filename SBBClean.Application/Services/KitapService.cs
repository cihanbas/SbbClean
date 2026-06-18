using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Services;

public class KitapService : IKitapService
{
    private readonly IKitapRepository _repo;
    private readonly IYazarRepository _yazarRepo;
    private readonly IUnitOfWorks _unitOfWork;

    public KitapService(IKitapRepository repo, IYazarRepository yazarRepo, IUnitOfWorks unitOfWork)
    {
        _repo = repo;
        _yazarRepo = yazarRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<KitapDto>> GetAllAsync()
    {
        var kitaplar = await _repo.GetAllAsync();
        return kitaplar.Select(k => new KitapDto
        {
            Id = k.Id,
            Title = k.Title,
            Date = k.Date,
            YazarId = k.YazarId
        }).ToList();
    }

    public async Task<KitapDto?> GetByIdAsync(int id)
    {
        var kitap = await _repo.GetByIdAsync(id);
        if (kitap is null) return null;

        return new KitapDto
        {
            Id = kitap.Id,
            Title = kitap.Title,
            Date = kitap.Date,
            YazarId = kitap.YazarId
        };
    }

    public async Task<KitapDto> CreateAsync(KitapCreateDto dto)
    {
        var yazar = await _yazarRepo.GetByIdAsync(dto.YazarId);
        if (yazar is null)
            throw new KeyNotFoundException($"{dto.YazarId} ID'li yazar bulunamadı.");

        var kitap = new Kitap
        {
            Title = dto.Title,
            Date = dto.Date,
            YazarId = dto.YazarId
        };

        await _repo.AddAsync(kitap);
        await _unitOfWork.SaveChangesAsync();

        return new KitapDto
        {
            Id = kitap.Id,
            Title = kitap.Title,
            Date = kitap.Date,
            YazarId = kitap.YazarId
        };
    }
}
