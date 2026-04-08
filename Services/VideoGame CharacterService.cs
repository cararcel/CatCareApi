using Characters.Data;
using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Dtos;
using VideoGameCharacterApi.Models;


namespace VideoGameCharacterApi.Services;

public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
{
    public Task<CharacterResponse> AddCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CharacterResponse>> GetAllCharactersAsync()
        => await context.Characters.Select(c => new CharacterResponse
        {
            Id = c.Id,
            Name = c.Name,
            Game = c.Game,
            Role = c.Role
        }).ToListAsync();
    public async Task<CharacterResponse?> GetCharacterByIdAsync(int id)
    {
        var result = await context.Characters
            .Where(c => c.Id == id)
            .Select(c => new CharacterResponse
            {
                Id = c.Id,
                Name = c.Name,
                Game = c.Game,
                Role = c.Role
            })
            .FirstOrDefaultAsync();

        return result;
    }

    public Task<bool> UpdateCharacterAsync(int id, Character character)
    {
        throw new NotImplementedException();
    }
    public Task<bool> DeletCharacterAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CharacterResponse>> GetAllCharacterAsync()
    {
        throw new NotImplementedException();
    }
}
