
using CSharpFunctionalExtensions;
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

    }
}
