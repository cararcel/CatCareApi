using Microsoft.AspNetCore.Mvc;
using CatCareApi.Dtos;
using CatCareApi.Services;

namespace CatCareApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BreedsController(ICatCareService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<BreedResponse>>> GetBreeds()
    {
        return Ok(await service.GetBreedsAsync());
    }

    [HttpPost]
    public async Task<ActionResult<BreedResponse>> AddBreed(CreateBreedRequest breed)
    {
        var createdBreed = await service.AddBreedAsync(breed);
        return CreatedAtAction(nameof(GetBreeds), new { id = createdBreed.Id }, createdBreed);
    }
}
