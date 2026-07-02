namespace CatCareApi.Models;

public class Breed
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Cat> Cats { get; set; } = [];
}
