using WebApp.API.Domain;

namespace WebApp.API.Contracts
{
    //DTO
    public record CreatePostRequest(
        string Name, 
        string Breed, 
        Weight Weight,
        int Height,
        bool Vaccine,
        DateOnly BirthDate,
        string Photo,
        string Description , 
        string Adress
        );

}
