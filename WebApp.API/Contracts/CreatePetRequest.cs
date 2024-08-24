using WebApp.Domain.Entities;
using WebApp.Domain.ValueObjects;

namespace WebApp.API.Contracts
{
    //DTO
    public record CreatePetRequest(
        string Name,
        string Breed,
        Weight Weight,
        int Height,
        bool Vaccine,
        DateTime BirthDate,
        List<Photo> Photos,
        string Description,
        string Adress
        );

}
