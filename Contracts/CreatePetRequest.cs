using System.Net;

namespace Contracts;

public class CreatePetRequest
{
    public string Nickname { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTimeOffset BirthDate { get; set; }
    public string Breed { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Street { get; set; } = string.Empty;

    public string Building { get; set; } = string.Empty;

    public string Index { get; set; } = string.Empty;

    public string Place { get; set; } = string.Empty;


    public bool Castration { get; set; } = false;  

    public string PeopleAttitude { get; set; }

    public string AnimalAttitude { get; set; }

    public string Health { get; set; }

    public bool OnlyOneInFamily { get; set; }

    public float Weight { get; set; }

    public int? Height { get; set; }


    public string? ContactPhoneNumber { get; set; }

    public string? VolunteerPhoneNumber { get; set; }
    public bool OnTreatment { get; set; }

    public DateTimeOffset CreatedTime { get; set; }

    public IReadOnlyCollection<VaccinationDTO> Vaccinations => _vaccinations;
    private readonly List<VaccinationDTO> _vaccinations = [];


    public IReadOnlyList<PhotoDTO> Photos => _photos;

    private readonly List<PhotoDTO> _photos = [];

}

public class VaccinationDTO
{
    public string Name { get; set; } = string.Empty;

    public DateTime Applied { get; set; }
}

public class PhotoDTO
{
    public string Path { get; set; }= string.Empty;

    public bool IsMain {  get; set; }= false;
}

