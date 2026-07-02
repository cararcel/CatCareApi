using Microsoft.AspNetCore.Mvc;
using CatCareApi.Dtos;
using CatCareApi.Services;

namespace CatCareApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatsController(ICatCareService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CatResponse>>> GetCats()
    {
        return Ok(await service.GetAllCatsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CatResponse>> GetCat(int id)
    {
        var cat = await service.GetCatByIdAsync(id);
        return cat is null ? NotFound("Cat with the given Id was not found.") : Ok(cat);
    }

    [HttpPost]
    public async Task<ActionResult<CatResponse>> AddCat(CreateCatRequest cat)
    {
        var createdCat = await service.AddCatAsync(cat);
        return createdCat is null
            ? BadRequest("OwnerId must reference an existing record. BreedId must reference an existing record when provided.")
            : CreatedAtAction(nameof(GetCat), new { id = createdCat.Id }, createdCat);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCat(int id, UpdateCatRequest cat)
    {
        var updated = await service.UpdateCatAsync(id, cat);
        return updated ? NoContent() : NotFound("Cat, owner, or provided breed with the given Id was not found.");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCat(int id)
    {
        var deleted = await service.DeleteCatAsync(id);
        return deleted ? NoContent() : NotFound("Cat with the given Id was not found.");
    }

    [HttpPost("{catId}/vet-visits")]
    public async Task<ActionResult<VetVisitResponse>> AddVetVisit(int catId, CreateVetVisitRequest vetVisit)
    {
        var createdVetVisit = await service.AddVetVisitAsync(catId, vetVisit);
        return createdVetVisit is null ? NotFound("Cat with the given Id was not found.") : Ok(createdVetVisit);
    }

    [HttpPost("{catId}/vaccines")]
    public async Task<ActionResult<VaccineResponse>> AddVaccine(int catId, CreateVaccineRequest vaccine)
    {
        var createdVaccine = await service.AddVaccineAsync(catId, vaccine);
        return createdVaccine is null ? NotFound("Cat with the given Id was not found.") : Ok(createdVaccine);
    }

    [HttpPost("{catId}/medications")]
    public async Task<ActionResult<MedicationResponse>> AddMedication(int catId, CreateMedicationRequest medication)
    {
        var createdMedication = await service.AddMedicationAsync(catId, medication);
        return createdMedication is null ? NotFound("Cat with the given Id was not found.") : Ok(createdMedication);
    }

    [HttpPost("{catId}/weights")]
    public async Task<ActionResult<WeightRecordResponse>> AddWeightRecord(int catId, CreateWeightRecordRequest weightRecord)
    {
        var createdWeightRecord = await service.AddWeightRecordAsync(catId, weightRecord);
        return createdWeightRecord is null ? NotFound("Cat with the given Id was not found.") : Ok(createdWeightRecord);
    }
}
