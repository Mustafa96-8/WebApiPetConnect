using Contracts;
using CSharpFunctionalExtensions;
using WebApp.Application.Abstractions;
using WebApp.Application.Services.IServices;
using WebApp.Domain.Common;
using WebApp.Domain.Entities;
using WebApp.Domain.ValueObjects;


namespace WebApp.Application.Services
{
    public class PetService(IPetsRepository petsRepository):IPetService
    {
        private readonly IPetsRepository _petsRepository= petsRepository;

        public async Task<Result<Guid, Error>> Create(CreatePetRequest request, CancellationToken ct)
        {
            var address = Address.Create(
                request.City,
                request.Street,
                request.Building,
                request.Index
                ).Value;

            var place = Place.Create(request.Place).Value;
            
            var weight = Weight.Create(request.Weight).Value;

            var contactPhoneNumber = PhoneNumber.Create(request.ContactPhoneNumber).Value;

            var volunteerPhoneNumber = PhoneNumber.Create(request.VolunteerPhoneNumber).Value;

            var vaccinations = Vaccination.Create(request.Vaccinations);



            var pet = Pet.Create(
                request.Nickname,
                request.Description,
                request.BirthDate,
                request.Breed,
                request.Color,
                address,
                place,
                request.Castration,
                request.PeopleAttitude,
                request.AnimalAttitude,
                request.Health,
                request.OnlyOneInFamily,
                weight,
                request.Height,
                contactPhoneNumber,
                volunteerPhoneNumber,
                request.OnTreatment,
                request.CreatedTime,
                new List<Vaccination>(),
                new List<Photo>());

            var id = await _petsRepository.Add(pet.Value, ct);
            if (id.IsFailure)
                return id.Error;    

            return id.Value;

        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Pet,Error>> Get(Guid id,CancellationToken ct)
        {
            var petFromDb = await _petsRepository.Get(id,ct);

            return petFromDb.Value;
        }

        public Task<List<Pet>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
