
using SBBClean.Domain.Entities;

namespace SBBClean.Application.DTOs;

public class UrunDto
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public decimal Fiyat { get; set; }

    public CategoryDto? Kategori { get; set; }
}
public class UrunCreateDto
{
    public string  Ad { get; set; } = string.Empty;
    public decimal Fiyat { get; set; }
    public int StokAdedi { get; set; }
    public int? kategoriId { get; set; }
}
