using Microsoft.EntityFrameworkCore;
using CatCareApi.Models;

namespace CatCareApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Cat> Cats => Set<Cat>();
    public DbSet<Breed> Breeds => Set<Breed>();
    public DbSet<Owner> Owners => Set<Owner>();
    public DbSet<VetVisit> VetVisits => Set<VetVisit>();
    public DbSet<Vaccine> Vaccines => Set<Vaccine>();
    public DbSet<Medication> Medications => Set<Medication>();
    public DbSet<WeightRecord> WeightRecords => Set<WeightRecord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
            .HasOne(cat => cat.Breed)
            .WithMany(breed => breed.Cats)
            .HasForeignKey(cat => cat.BreedId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Cat>()
            .HasOne(cat => cat.Owner)
            .WithMany(owner => owner.Cats)
            .HasForeignKey(cat => cat.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WeightRecord>()
            .Property(weight => weight.WeightKg)
            .HasPrecision(5, 2);
    }
}
