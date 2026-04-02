using VideoGameCharacterApi.Models;


namespace VideoGameCharacterApi.Services;

public class VideoGameCharacterService : IVideoGameCharacterService
{
    static List<Character> characters = new List<Character>{
        new Character {Id = 1, Name = "Mario", Game = "Super Mario Bros.", Role = "Hero"},
        new Character {Id = 2, Name = "Link", Game = "The legend of Zelda", Role = "Hero"},
        new Character {Id = 3, Name = "Bowser", Game = "Super Mario Bros", Role = "Hero"},
        new Character {Id = 4, Name = "Cruella Devile", Game = "102 Dalmatians", Role = "Villain"},
    };
    public Task<Character> AddCharacterAsync(Character character)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletCharacterAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Character>> GetAllCharacterAsync()
        => await Task.FromResult(characters);


    public async Task<Character> GetCharacterByIdAsync(int id)
    {
        var result = Character.FirstOrDefault(c => c.Id == id);
    }

    public Task<bool> UpdateCharacterAsync(int id, Character character)
    {
        throw new NotImplementedException();
    }
}
