using CSharpFunctionalExtensions;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using WebApp.Domain.Common;
using WebApp.Domain.ValueObjects;

namespace WebApp.Domain.Entities
{
    public class Pet
    {
        public const int MAX_NAME_LENGTH = 100;
        private Pet()
        {
            
        }
        public Guid Id { get; private set; }
        public string Nickname { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public DateTimeOffset BirthDate { get; private set; }
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


        public PhoneNumber ContactPhoneNumber { get; private set; }

        public PhoneNumber VolunteerPhoneNumber { get; private set; }
        public bool OnTreatment { get; private set; }

        public DateTimeOffset CreatedTime { get; private set; }

        public IReadOnlyCollection<Vaccination> Vaccinations=> _vaccinations;
        private readonly List<Vaccination> _vaccinations = [];


        public IReadOnlyList<Photo> Photos => _photos;

        private readonly List<Photo> _photos = [];

        private Pet(
            string nickname,
            string description,
            DateTimeOffset birthDate,
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
            PhoneNumber contactPhoneNumber,
            PhoneNumber volunteerPhoneNumber,
            bool onTreatment,
            DateTimeOffset createdTime/*,
            List<Vaccination> vaccinations,
            List<Photo> photos*/
            )
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
            Weight = weight;
            ContactPhoneNumber = contactPhoneNumber;
            VolunteerPhoneNumber = volunteerPhoneNumber;
            OnTreatment = onTreatment;
            CreatedTime = createdTime;
            //_vaccinations = vaccinations;
        }

        public static Result<Pet,Error> Create(
            string nickname,
            string description,
            DateTimeOffset birthDate,
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
            PhoneNumber contactPhoneNumber,
            PhoneNumber volunteerPhoneNumber,
            bool onTreatment,
            DateTimeOffset createdTime,
            List<Vaccination> vaccinations,
            List<Photo> photos
            )
        {
            if (nickname.IsEmpty() || nickname.Length>MAX_NAME_LENGTH)
                return Errors.General.InvalidLength(nickname);

            if (color.IsEmpty())
                return Errors.General.ValueIsRequired(nameof(color));

            if (health.IsEmpty())
                return Errors.General.ValueIsRequired(nameof(color));

            return new Pet(
                nickname,
                description,
                birthDate,
                breed,
                color,
                address,
                place,
                castration,
                peopleAttitude,
                animalAttitude,
                health,
                onlyOneInFamily,
                weight,
                height,
                contactPhoneNumber,
                volunteerPhoneNumber,
                onTreatment,
                createdTime,
                vaccinations,
                photos
                );
        }
    }
}

