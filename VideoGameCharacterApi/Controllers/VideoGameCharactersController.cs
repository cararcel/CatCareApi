using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacterApi.Models;
using VideoGameCharacterApi.Services;

namespace VideoGameCharacterApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class VideoGameCharactersController(IVideoGameCharacterService service) : ControllerBase
{
    static List<Character> characters = new List<Character>
        {
            new Character {Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero"},
            new Character {Id = 2, Name = "Link", Game = "The legend of Zelda", Role = "Hero"},
            new Character {Id = 3, Name = "Bowser", Game = "Super Mario Bros", Role = "Hero"},
        };
    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetCharacters()
        => Ok(await service.GetAllCharacterAsync());

    [HttpGet("{id}")]
}