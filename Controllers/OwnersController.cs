using Microsoft.AspNetCore.Mvc;
using CatCareApi.Dtos;
using CatCareApi.Services;

namespace CatCareApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnersController(ICatCareService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OwnerResponse>>> GetOwners()
    {
        return Ok(await service.GetOwnersAsync());
    }

    [HttpPost]
    public async Task<ActionResult<OwnerResponse>> AddOwner(CreateOwnerRequest owner)
    {
        var createdOwner = await service.AddOwnerAsync(owner);
        return CreatedAtAction(nameof(GetOwners), new { id = createdOwner.Id }, createdOwner);
    }
}
