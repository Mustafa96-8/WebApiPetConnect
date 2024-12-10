
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.Generic;
using System.Formats.Asn1;
using WebApp.Application.Abstractions;
using WebApp.Application.Services.IServices;
using WebApp.Domain.Common;
using WebApp.Domain.Entities;
using WebApp.Infrastracture;

namespace WebApp.Infrastructure.Reositories
{
    public class PetRepository : IPetsRepository
    {

        private readonly PetFamilyDbContext _dbContext;

        public PetRepository(PetFamilyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<Guid, Error>> Add(Pet pet, CancellationToken ct)
        {
            await _dbContext.AddAsync(pet, ct);
            var result = await _dbContext.SaveChangesAsync(ct);
            if (result ==0 )
                return new Error("record.save","Pet can not be save");

            return pet.Id;
        }

        public async Task<Result<Pet, Error>> Get(Guid id, CancellationToken ct)
        {
            var Pet = await _dbContext.Pets.FirstOrDefaultAsync(u => u.Id == id,ct);
                      
            if (Pet == null)
                return new Error("record.notfound", $"Pet can not be found, by id = {id}");
            
            return Pet;
        }

        public async Task<Result<IEnumerable<Pet>, Error>> GetAll(CancellationToken ct, string? includeProperties = null)
        {
            var Pets = await _dbContext.Pets.ToListAsync(ct);

            return Pets;

        }

    }
}
