namespace SBBClean.Domain.Entities;

public class Yazar
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string Soyad { get; set; } = string.Empty;
    public List<Kitap>? Kitaplar { get; set; }
}