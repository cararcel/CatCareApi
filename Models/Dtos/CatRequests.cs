namespace CatCareApi.Dtos;

public class CreateCatRequest
{
    public string Name { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string Sex { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string MicrochipNumber { get; set; } = string.Empty;
    public int? BreedId { get; set; }
    public int OwnerId { get; set; }
}

public class UpdateCatRequest
{
    public string Name { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string Sex { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string MicrochipNumber { get; set; } = string.Empty;
    public int? BreedId { get; set; }
    public int OwnerId { get; set; }
}

public class CreateBreedRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class CreateOwnerRequest
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

public class CreateVetVisitRequest
{
    public DateTime VisitDate { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string VeterinarianName { get; set; } = string.Empty;
    public string Reason { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public DateTime? FollowUpDate { get; set; }
}

public class CreateVaccineRequest
{
    public string Name { get; set; } = string.Empty;
    public DateTime AdministeredDate { get; set; }
    public DateTime? DueDate { get; set; }
    public string ClinicName { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}

public class CreateMedicationRequest
{
    public string Name { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Notes { get; set; } = string.Empty;
}

public class CreateWeightRecordRequest
{
    public DateTime RecordedAt { get; set; }
    public decimal WeightKg { get; set; }
    public string Notes { get; set; } = string.Empty;
}
