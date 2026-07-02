namespace CatCareApi.Models;

public class WeightRecord
{
    public int Id { get; set; }
    public DateTime RecordedAt { get; set; }
    public decimal WeightKg { get; set; }
    public string Notes { get; set; } = string.Empty;

    public int CatId { get; set; }
    public Cat? Cat { get; set; }
}
