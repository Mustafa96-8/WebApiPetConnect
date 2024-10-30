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
                );
            if (address.IsFailure)
                return address.Error;

            var place = Place.Create(request.Place);
            if (place.IsFailure)
                return place.Error;
            
            var weight = Weight.Create(request.Weight);
            if (weight.IsFailure)
                return weight.Error;

            var contactPhoneNumber = PhoneNumber.Create(request.ContactPhoneNumber);
            if (contactPhoneNumber.IsFailure)
                return contactPhoneNumber.Error;

            var volunteerPhoneNumber = PhoneNumber.Create(request.VolunteerPhoneNumber);
            if (volunteerPhoneNumber.IsFailure) 
                return volunteerPhoneNumber.Error;



            var pet = Pet.Create(
                request.Nickname,
                request.Description,
                request.BirthDate,
                request.Breed,
                request.Color,
                address.Value,
                place.Value,
                request.Castration,
                request.PeopleAttitude,
                request.AnimalAttitude,
                request.Health,
                request.OnlyOneInFamily,
                weight.Value,
                request.Height,
                contactPhoneNumber.Value,
                volunteerPhoneNumber.Value,
                request.OnTreatment,
                request.CreatedTime);

            var id = await _petsRepository.Add(pet.Value, ct);
            if (id.IsFailure)
                return id.Error;    

            return id.Value;

        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pet> Get(Guid id)
        {
            throw new NotImplementedException();

        }

        public Task<List<Pet>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
