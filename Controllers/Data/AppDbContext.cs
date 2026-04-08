using Microsoft.EntityFrameworkCore;
using VideoGameCharacterApi.Models;

namespace Characters.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // DbSet represents a table in the database (e.g., Products table)  
    public DbSet<Character> Characters => Set<Character>();

}

