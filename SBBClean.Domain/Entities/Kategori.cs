namespace SBBClean.Domain.Entities;

public class Kategori
{
    public int Id { get; set; }
    public string Ad { get; set; }=string.Empty;
    public List<Urun> Urunler { get; set; } = new();
}