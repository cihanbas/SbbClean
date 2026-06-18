namespace SBBClean.Application.DTOs;

public class KitapDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int YazarId { get; set; }
}

public class KitapCreateDto
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int YazarId { get; set; }
}