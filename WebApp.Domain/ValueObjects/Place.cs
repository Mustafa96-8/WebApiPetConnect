using CSharpFunctionalExtensions;
using WebApp.Domain.Common;

namespace WebApp.Domain.ValueObjects
{
    public record Place
    {
        public static readonly Place InHospital = new(nameof(InHospital));
        public static readonly Place AtHome = new(nameof(AtHome));

        private static readonly Place[] _all = [InHospital, AtHome];

        public string Value { get; }

        private Place(string value)
        {
            Value = value;
        }

        public static Result<Place,Error> Create(string input)
        {
            input = input.Trim();
            if (input.Length <1)
            {
                return Errors.General.InvalidLength("place");
            }
            var place = input.ToUpper();
            if (_all.Any(p => p.Value.ToUpper() == place) == false)
            {
                return Errors.General.ValueIsInvalid(nameof(Place));
            }
            return new Place(place);
        }
    }
}

