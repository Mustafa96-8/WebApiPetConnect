using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using WebApp.Domain.ValueObjects;

namespace WebApp.Domain.Entities
{
    public class Pet
    {

        private Pet()
        {
            
        }
        public Guid Id { get; private set; }
        public string Nickname { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public DateTime BirthDate { get; private set; }
        public string Breed { get; private set; } = string.Empty;

        public string Color { get; private set; }

        public Address Address { get; private set; }

        public Place Place { get; private set; }

        
        public bool Castration { get; private set; }

        public string PeopleAttitude { get; private set; }

        public string AnimalAttitude { get; private set; }

        public string Health { get; private set; }

        public bool OnlyOneInFamily { get; private set; }

        public Weight Weight { get; private set; }

        public int? Height { get; private set; }

        public bool Vaccine { get; private set; }

        public PhoneNumber ContactPhoneNumber { get; private set; }

        public PhoneNumber VolunteerPhoneNumber { get; private set; }
        public bool OnTreatment { get; private set; }

        public DateTime CreatedTime { get; private set; }

        public IReadOnlyCollection<Vaccination> Vaccinations=> _vaccinations;
        private readonly List<Vaccination> _vaccinations = [];


        public IReadOnlyList<Photo> Photos => _photos;

        private readonly List<Photo> _photos = [];

        public Pet(
            string nickname,
            string description,
            DateTime birthDate,
            string breed,
            string color,
            Address address,
            Place place,
            bool castration,
            string peopleAttitude,
            string animalAttitude,
            string health,
            bool onlyOneInFamily,
            Weight weight,
            int? height,
            bool vaccine,
            PhoneNumber contactPhoneNumber,
            PhoneNumber volunteerPhoneNumber,
            bool onTreatment,
            DateTime createdTime,
            List<Vaccination> vaccinations,
            List<Photo> photos,
            string name,
            string adress)
        {
            Nickname = nickname;
            Description = description;
            BirthDate = birthDate;
            Breed = breed;
            Color = color;
            Address = address;
            Place = place;
            Castration = castration;
            PeopleAttitude = peopleAttitude;
            AnimalAttitude = animalAttitude;
            Health = health;
            OnlyOneInFamily = onlyOneInFamily;
            Height = height;
            Vaccine = vaccine;
            Weight = weight;
            ContactPhoneNumber = contactPhoneNumber;
            VolunteerPhoneNumber = volunteerPhoneNumber;
            OnTreatment = onTreatment;
            CreatedTime = createdTime;
            _vaccinations = vaccinations;
        }
    }
}

