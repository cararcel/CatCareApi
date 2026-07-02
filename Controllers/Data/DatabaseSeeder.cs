using CatCareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CatCareApi.Data;

public static class DatabaseSeeder
{
    public static async Task SeedDevelopmentDataAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        if (await context.Cats.AnyAsync())
            return;

        var domesticShorthair = new Breed
        {
            Name = "Domestic Shorthair",
            Description = "Mixed-breed short-haired cat."
        };

        var maineCoon = new Breed
        {
            Name = "Maine Coon",
            Description = "Large, friendly long-haired breed."
        };

        var owners = new List<Owner>
        {
            new()
            {
                FullName = "Cami Rivera",
                Email = "cami@example.com",
                PhoneNumber = "+32 470 111 222",
                Address = "Brussels"
            },
            new()
            {
                FullName = "Alex Morgan",
                Email = "alex@example.com",
                PhoneNumber = "+32 470 333 444",
                Address = "Ghent"
            }
        };

        var cats = new List<Cat>
        {
            new()
            {
                Name = "Milo",
                DateOfBirth = new DateTime(2022, 5, 14),
                Sex = "Male",
                Color = "Black and white",
                MicrochipNumber = "981020000000001",
                Breed = domesticShorthair,
                Owner = owners[0],
                VetVisits =
                [
                    new()
                    {
                        VisitDate = new DateTime(2026, 6, 5, 9, 30, 0),
                        ClinicName = "Central Vet Clinic",
                        VeterinarianName = "Dr. Smith",
                        Reason = "Annual wellness exam",
                        Notes = "Healthy exam. Mild tartar noted.",
                        FollowUpDate = new DateTime(2027, 6, 5, 9, 30, 0)
                    }
                ],
                Vaccines =
                [
                    new()
                    {
                        Name = "Rabies",
                        AdministeredDate = new DateTime(2026, 6, 5),
                        DueDate = new DateTime(2027, 6, 5),
                        ClinicName = "Central Vet Clinic",
                        Notes = "No reaction observed."
                    }
                ],
                Medications =
                [
                    new()
                    {
                        Name = "Flea prevention",
                        Dosage = "1 pipette",
                        Frequency = "Monthly",
                        StartDate = new DateTime(2026, 6, 5),
                        Notes = "Apply between shoulder blades."
                    }
                ],
                WeightRecords =
                [
                    new()
                    {
                        RecordedAt = new DateTime(2026, 6, 5, 9, 30, 0),
                        WeightKg = 4.65m,
                        Notes = "Measured at annual checkup."
                    },
                    new()
                    {
                        RecordedAt = new DateTime(2026, 1, 10, 10, 0, 0),
                        WeightKg = 4.48m,
                        Notes = "Home scale reading."
                    }
                ]
            },
            new()
            {
                Name = "Luna",
                DateOfBirth = new DateTime(2020, 9, 3),
                Sex = "Female",
                Color = "Silver tabby",
                MicrochipNumber = "981020000000002",
                Breed = maineCoon,
                Owner = owners[1],
                VetVisits =
                [
                    new()
                    {
                        VisitDate = new DateTime(2026, 4, 18, 14, 0, 0),
                        ClinicName = "Northside Animal Hospital",
                        VeterinarianName = "Dr. Vermeulen",
                        Reason = "Dental cleaning follow-up",
                        Notes = "Recovery looks good.",
                        FollowUpDate = null
                    }
                ],
                Vaccines =
                [
                    new()
                    {
                        Name = "FVRCP",
                        AdministeredDate = new DateTime(2026, 4, 18),
                        DueDate = new DateTime(2027, 4, 18),
                        ClinicName = "Northside Animal Hospital",
                        Notes = "Booster completed."
                    }
                ],
                WeightRecords =
                [
                    new()
                    {
                        RecordedAt = new DateTime(2026, 4, 18, 14, 0, 0),
                        WeightKg = 6.2m,
                        Notes = "Healthy weight for frame."
                    }
                ]
            },
            new()
            {
                Name = "Nori",
                DateOfBirth = null,
                Sex = "Female",
                Color = "Tortoiseshell",
                MicrochipNumber = string.Empty,
                Breed = null,
                Owner = owners[0],
                VetVisits =
                [
                    new()
                    {
                        VisitDate = new DateTime(2026, 2, 9, 11, 15, 0),
                        ClinicName = "Central Vet Clinic",
                        VeterinarianName = "Dr. Smith",
                        Reason = "New adoption checkup",
                        Notes = "Estimated adult age. Breed unknown.",
                        FollowUpDate = new DateTime(2026, 8, 9, 11, 15, 0)
                    }
                ],
                WeightRecords =
                [
                    new()
                    {
                        RecordedAt = new DateTime(2026, 2, 9, 11, 15, 0),
                        WeightKg = 3.9m,
                        Notes = "Initial adoption visit."
                    }
                ]
            }
        };

        context.Cats.AddRange(cats);
        await context.SaveChangesAsync();
    }
}
