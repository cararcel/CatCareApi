using CatCareApi.Data;
using Microsoft.EntityFrameworkCore;
using CatCareApi.Dtos;
using CatCareApi.Models;

namespace CatCareApi.Services;

public class CatCareService(AppDbContext context) : ICatCareService
{
    public async Task<CatResponse?> AddCatAsync(CreateCatRequest cat)
    {
        var hasBreed = cat.BreedId is null || await context.Breeds.AnyAsync(breed => breed.Id == cat.BreedId);
        var hasOwner = await context.Owners.AnyAsync(owner => owner.Id == cat.OwnerId);

        if (!hasBreed || !hasOwner)
            return null;

        var newCat = new Cat
        {
            Name = cat.Name,
            DateOfBirth = cat.DateOfBirth,
            Sex = cat.Sex,
            Color = cat.Color,
            MicrochipNumber = cat.MicrochipNumber,
            BreedId = cat.BreedId,
            OwnerId = cat.OwnerId
        };

        context.Cats.Add(newCat);
        await context.SaveChangesAsync();

        return await GetCatByIdAsync(newCat.Id);
    }

    public async Task<bool> DeleteCatAsync(int id)
    {
        var catToDelete = await context.Cats.FindAsync(id);
        if (catToDelete is null)
            return false;

        context.Cats.Remove(catToDelete);
        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<CatResponse>> GetAllCatsAsync()
        => await CatProfiles()
            .OrderBy(cat => cat.Name)
            .ToListAsync();

    public async Task<CatResponse?> GetCatByIdAsync(int id)
        => await CatProfiles()
            .FirstOrDefaultAsync(cat => cat.Id == id);

    public async Task<bool> UpdateCatAsync(int id, UpdateCatRequest cat)
    {
        var existingCat = await context.Cats.FindAsync(id);
        if (existingCat is null)
            return false;

        var hasBreed = cat.BreedId is null || await context.Breeds.AnyAsync(breed => breed.Id == cat.BreedId);
        var hasOwner = await context.Owners.AnyAsync(owner => owner.Id == cat.OwnerId);

        if (!hasBreed || !hasOwner)
            return false;

        existingCat.Name = cat.Name;
        existingCat.DateOfBirth = cat.DateOfBirth;
        existingCat.Sex = cat.Sex;
        existingCat.Color = cat.Color;
        existingCat.MicrochipNumber = cat.MicrochipNumber;
        existingCat.BreedId = cat.BreedId;
        existingCat.OwnerId = cat.OwnerId;

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<List<BreedResponse>> GetBreedsAsync()
        => await context.Breeds
            .OrderBy(breed => breed.Name)
            .Select(breed => new BreedResponse
            {
                Id = breed.Id,
                Name = breed.Name,
                Description = breed.Description
            })
            .ToListAsync();

    public async Task<BreedResponse> AddBreedAsync(CreateBreedRequest breed)
    {
        var newBreed = new Breed
        {
            Name = breed.Name,
            Description = breed.Description
        };

        context.Breeds.Add(newBreed);
        await context.SaveChangesAsync();

        return new BreedResponse
        {
            Id = newBreed.Id,
            Name = newBreed.Name,
            Description = newBreed.Description
        };
    }

    public async Task<List<OwnerResponse>> GetOwnersAsync()
        => await context.Owners
            .OrderBy(owner => owner.FullName)
            .Select(owner => new OwnerResponse
            {
                Id = owner.Id,
                FullName = owner.FullName,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber,
                Address = owner.Address
            })
            .ToListAsync();

    public async Task<OwnerResponse> AddOwnerAsync(CreateOwnerRequest owner)
    {
        var newOwner = new Owner
        {
            FullName = owner.FullName,
            Email = owner.Email,
            PhoneNumber = owner.PhoneNumber,
            Address = owner.Address
        };

        context.Owners.Add(newOwner);
        await context.SaveChangesAsync();

        return new OwnerResponse
        {
            Id = newOwner.Id,
            FullName = newOwner.FullName,
            Email = newOwner.Email,
            PhoneNumber = newOwner.PhoneNumber,
            Address = newOwner.Address
        };
    }

    public async Task<VetVisitResponse?> AddVetVisitAsync(int catId, CreateVetVisitRequest vetVisit)
    {
        if (!await CatExistsAsync(catId))
            return null;

        var newVetVisit = new VetVisit
        {
            CatId = catId,
            VisitDate = vetVisit.VisitDate,
            ClinicName = vetVisit.ClinicName,
            VeterinarianName = vetVisit.VeterinarianName,
            Reason = vetVisit.Reason,
            Notes = vetVisit.Notes,
            FollowUpDate = vetVisit.FollowUpDate
        };

        context.VetVisits.Add(newVetVisit);
        await context.SaveChangesAsync();

        return new VetVisitResponse
        {
            Id = newVetVisit.Id,
            VisitDate = newVetVisit.VisitDate,
            ClinicName = newVetVisit.ClinicName,
            VeterinarianName = newVetVisit.VeterinarianName,
            Reason = newVetVisit.Reason,
            Notes = newVetVisit.Notes,
            FollowUpDate = newVetVisit.FollowUpDate
        };
    }

    public async Task<VaccineResponse?> AddVaccineAsync(int catId, CreateVaccineRequest vaccine)
    {
        if (!await CatExistsAsync(catId))
            return null;

        var newVaccine = new Vaccine
        {
            CatId = catId,
            Name = vaccine.Name,
            AdministeredDate = vaccine.AdministeredDate,
            DueDate = vaccine.DueDate,
            ClinicName = vaccine.ClinicName,
            Notes = vaccine.Notes
        };

        context.Vaccines.Add(newVaccine);
        await context.SaveChangesAsync();

        return new VaccineResponse
        {
            Id = newVaccine.Id,
            Name = newVaccine.Name,
            AdministeredDate = newVaccine.AdministeredDate,
            DueDate = newVaccine.DueDate,
            ClinicName = newVaccine.ClinicName,
            Notes = newVaccine.Notes
        };
    }

    public async Task<MedicationResponse?> AddMedicationAsync(int catId, CreateMedicationRequest medication)
    {
        if (!await CatExistsAsync(catId))
            return null;

        var newMedication = new Medication
        {
            CatId = catId,
            Name = medication.Name,
            Dosage = medication.Dosage,
            Frequency = medication.Frequency,
            StartDate = medication.StartDate,
            EndDate = medication.EndDate,
            Notes = medication.Notes
        };

        context.Medications.Add(newMedication);
        await context.SaveChangesAsync();

        return new MedicationResponse
        {
            Id = newMedication.Id,
            Name = newMedication.Name,
            Dosage = newMedication.Dosage,
            Frequency = newMedication.Frequency,
            StartDate = newMedication.StartDate,
            EndDate = newMedication.EndDate,
            Notes = newMedication.Notes
        };
    }

    public async Task<WeightRecordResponse?> AddWeightRecordAsync(int catId, CreateWeightRecordRequest weightRecord)
    {
        if (!await CatExistsAsync(catId))
            return null;

        var newWeightRecord = new WeightRecord
        {
            CatId = catId,
            RecordedAt = weightRecord.RecordedAt,
            WeightKg = weightRecord.WeightKg,
            Notes = weightRecord.Notes
        };

        context.WeightRecords.Add(newWeightRecord);
        await context.SaveChangesAsync();

        return new WeightRecordResponse
        {
            Id = newWeightRecord.Id,
            RecordedAt = newWeightRecord.RecordedAt,
            WeightKg = newWeightRecord.WeightKg,
            Notes = newWeightRecord.Notes
        };
    }

    private Task<bool> CatExistsAsync(int catId)
        => context.Cats.AnyAsync(cat => cat.Id == catId);

    private IQueryable<CatResponse> CatProfiles()
        => context.Cats
            .AsNoTracking()
            .Select(cat => new CatResponse
            {
                Id = cat.Id,
                Name = cat.Name,
                DateOfBirth = cat.DateOfBirth,
                Sex = cat.Sex,
                Color = cat.Color,
                MicrochipNumber = cat.MicrochipNumber,
                Breed = cat.Breed == null
                    ? null
                    : new BreedResponse
                    {
                        Id = cat.Breed.Id,
                        Name = cat.Breed.Name,
                        Description = cat.Breed.Description
                    },
                Owner = cat.Owner == null
                    ? null
                    : new OwnerResponse
                    {
                        Id = cat.Owner.Id,
                        FullName = cat.Owner.FullName,
                        Email = cat.Owner.Email,
                        PhoneNumber = cat.Owner.PhoneNumber,
                        Address = cat.Owner.Address
                    },
                VetVisits = cat.VetVisits
                    .OrderByDescending(vetVisit => vetVisit.VisitDate)
                    .Select(vetVisit => new VetVisitResponse
                    {
                        Id = vetVisit.Id,
                        VisitDate = vetVisit.VisitDate,
                        ClinicName = vetVisit.ClinicName,
                        VeterinarianName = vetVisit.VeterinarianName,
                        Reason = vetVisit.Reason,
                        Notes = vetVisit.Notes,
                        FollowUpDate = vetVisit.FollowUpDate
                    })
                    .ToList(),
                Vaccines = cat.Vaccines
                    .OrderByDescending(vaccine => vaccine.AdministeredDate)
                    .Select(vaccine => new VaccineResponse
                    {
                        Id = vaccine.Id,
                        Name = vaccine.Name,
                        AdministeredDate = vaccine.AdministeredDate,
                        DueDate = vaccine.DueDate,
                        ClinicName = vaccine.ClinicName,
                        Notes = vaccine.Notes
                    })
                    .ToList(),
                Medications = cat.Medications
                    .OrderByDescending(medication => medication.StartDate)
                    .Select(medication => new MedicationResponse
                    {
                        Id = medication.Id,
                        Name = medication.Name,
                        Dosage = medication.Dosage,
                        Frequency = medication.Frequency,
                        StartDate = medication.StartDate,
                        EndDate = medication.EndDate,
                        Notes = medication.Notes
                    })
                    .ToList(),
                WeightRecords = cat.WeightRecords
                    .OrderByDescending(weightRecord => weightRecord.RecordedAt)
                    .Select(weightRecord => new WeightRecordResponse
                    {
                        Id = weightRecord.Id,
                        RecordedAt = weightRecord.RecordedAt,
                        WeightKg = weightRecord.WeightKg,
                        Notes = weightRecord.Notes
                    })
                    .ToList()
            });
}
