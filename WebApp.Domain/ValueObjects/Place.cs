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

        public static Place Create(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException();
            }

            var place = input.Trim().ToUpper();
            if (_all.Any(p => p.Value.ToUpper() == input) == false)
            {
                throw new ArgumentException();
            }
            return new(place);
        }
    }
}

