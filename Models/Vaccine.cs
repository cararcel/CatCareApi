namespace CatCareApi.Models;

public class Vaccine
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime AdministeredDate { get; set; }
    public DateTime? DueDate { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;

    public int CatId { get; set; }
    public Cat? Cat { get; set; }
}
