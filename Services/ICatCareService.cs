using CatCareApi.Dtos;

namespace CatCareApi.Services;

public interface ICatCareService
{
    Task<List<CatResponse>> GetAllCatsAsync();
    Task<CatResponse?> GetCatByIdAsync(int id);
    Task<CatResponse?> AddCatAsync(CreateCatRequest cat);
    Task<bool> UpdateCatAsync(int id, UpdateCatRequest cat);
    Task<bool> DeleteCatAsync(int id);

    Task<List<BreedResponse>> GetBreedsAsync();
    Task<BreedResponse> AddBreedAsync(CreateBreedRequest breed);
    Task<List<OwnerResponse>> GetOwnersAsync();
    Task<OwnerResponse> AddOwnerAsync(CreateOwnerRequest owner);

    Task<VetVisitResponse?> AddVetVisitAsync(int catId, CreateVetVisitRequest vetVisit);
    Task<VaccineResponse?> AddVaccineAsync(int catId, CreateVaccineRequest vaccine);
    Task<MedicationResponse?> AddMedicationAsync(int catId, CreateMedicationRequest medication);
    Task<WeightRecordResponse?> AddWeightRecordAsync(int catId, CreateWeightRecordRequest weightRecord);
}
