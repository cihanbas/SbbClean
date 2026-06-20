using AutoMapper;
using SBBClean.Application.DTOs;
using SBBClean.Application.Interfaces;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Services;

public class KitapService : IKitapService
{
    private readonly IKitapRepository _repo;
    private readonly IYazarRepository _yazarRepo;
    private readonly IUnitOfWorks _unitOfWork;
    private readonly IMapper _mapper;

    public KitapService(IKitapRepository repo, IYazarRepository yazarRepo, IUnitOfWorks unitOfWork, IMapper mapper)
    {
        _repo = repo;
        _yazarRepo = yazarRepo;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<KitapDto>> GetAllAsync()
    {
        var kitaplar = await _repo.GetAllAsync();
        return _mapper.Map<List<KitapDto>>(kitaplar);
    }

    public async Task<KitapDto?> GetByIdAsync(int id)
    {
        var kitap = await _repo.GetByIdAsync(id);
        return _mapper.Map<KitapDto?>(kitap);
    }

    public async Task<KitapDto> CreateAsync(KitapCreateDto dto)
    {
        var yazar = await _yazarRepo.GetByIdAsync(dto.YazarId);
        if (yazar is null)
            throw new KeyNotFoundException($"{dto.YazarId} ID'li yazar bulunamadı.");

        var kitap = _mapper.Map<Kitap>(dto);
        await _repo.AddAsync(kitap);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<KitapDto>(kitap);
    }
}
