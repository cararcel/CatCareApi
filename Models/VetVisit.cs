namespace CatCareApi.Models;

public class VetVisit
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string VeterinarianName { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime? FollowUpDate { get; set; }

    public int CatId { get; set; }
    public Cat? Cat { get; set; }
}
