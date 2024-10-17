using Contracts;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.Services.IServices;
using WebApp.Domain.Common;
using WebApp.Domain.Entities;
using WebApp.Domain.ValueObjects;
using WebApp.Infrastracture;


namespace WebApp.Application.Services
{
    public class PetService(PetFamilyDbContext petFamilyDbContext) : IPetService
    {
        private readonly PetFamilyDbContext _petFamilyDbContext = petFamilyDbContext;

        public Result<Pet,Error> Create(CreatePetRequest petRequest)
        {
            var address = Address.Create(
                petRequest.City,
                petRequest.Street,
                petRequest.Building,
                petRequest.Index
                );
            if (address.IsFailure) 
            {
                return address.Error;
            }
            var NewPet = Pet.Create(
                petRequest.Nickname,
                petRequest.Description,
                petRequest.BirthDate,
                petRequest.Breed,
                petRequest.Color,
                petRequest.Address,
            if (NewPet.IsFaulted)
                return BadRequest(NewPet.Error);

        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pet> Get(Guid id)
        {
            var Pet = await _petFamilyDbContext.Pets.FirstOrDefaultAsync(p=> p.Id == id);
            return Pet;

        }

        public Task<List<Pet>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
