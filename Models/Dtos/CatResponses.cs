namespace CatCareApi.Dtos;

public class CatResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string Sex { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string MicrochipNumber { get; set; } = string.Empty;
    public BreedResponse? Breed { get; set; }
    public OwnerResponse? Owner { get; set; }
    public List<VetVisitResponse> VetVisits { get; set; } = [];
    public List<VaccineResponse> Vaccines { get; set; } = [];
    public List<MedicationResponse> Medications { get; set; } = [];
    public List<WeightRecordResponse> WeightRecords { get; set; } = [];
}

public class BreedResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class OwnerResponse
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

public class VetVisitResponse
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string VeterinarianName { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime? FollowUpDate { get; set; }
}

public class VaccineResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime AdministeredDate { get; set; }
    public DateTime? DueDate { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}

public class MedicationResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class WeightRecordResponse
{
    public int Id { get; set; }
    public DateTime RecordedAt { get; set; }
    public decimal WeightKg { get; set; }
    public string Notes { get; set; } = string.Empty;
}
