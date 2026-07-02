namespace CatCareApi.Models;

public class Cat
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string Sex { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string MicrochipNumber { get; set; } = string.Empty;

    public int? BreedId { get; set; }
    public Breed? Breed { get; set; }

    public int OwnerId { get; set; }
    public Owner? Owner { get; set; }

    public List<VetVisit> VetVisits { get; set; } = [];
    public List<Vaccine> Vaccines { get; set; } = [];
    public List<Medication> Medications { get; set; } = [];
    public List<WeightRecord> WeightRecords { get; set; } = [];
}
