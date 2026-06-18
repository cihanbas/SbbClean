using SBBClean.Domain.Entities;

namespace SBBClean.Application.DTOs;

public class YazarDto
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public List<KitapDto>? Kitaplar { get; set; }
}
