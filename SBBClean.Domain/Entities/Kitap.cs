namespace SBBClean.Domain.Entities;

public class Kitap
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int YazarId { get; set; }
    public Yazar Yazar { get; set; } = null!;
}