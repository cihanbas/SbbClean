using AutoMapper;
using SBBClean.Application.DTOs;
using SBBClean.Domain.Entities;

namespace SBBClean.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Kitap, KitapDto>();
        CreateMap<KitapCreateDto, Kitap>();

        CreateMap<Yazar, YazarDto>();

        CreateMap<Urun, UrunDto>();
        CreateMap<UrunCreateDto, Urun>();

        CreateMap<Kategori, CategoryDto>();
        CreateMap<CategoryDto, Kategori>();

        CreateMap<YazarDto, Yazar>();
    }
}
