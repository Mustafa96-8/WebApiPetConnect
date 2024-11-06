using CSharpFunctionalExtensions;
using WebApp.Domain.Common;

namespace WebApp.Domain.ValueObjects
{
    public record Address
    {

        const int PROPERTYMAXLENGTH = 100;
        private Address(string city, string street, string building, string index)
        {
            City = city;
            Street = street;
            Building = building;
            Index = index;
        }

        public string City { get; private set; }

        public string Street { get; private set; }

        public string Building { get; private set; }

        public string Index { get; private set; }

        public static Result<Address,Error > Create(string city, string street, string building, string index)
        {
            city = city.Trim();
            street = street.Trim();
            building = building.Trim();
            index = index.Trim();

            if (city.Length is <1 or >PROPERTYMAXLENGTH) 
                return Errors.General.InvalidLength("city");
            if (street.Length is  < 1 or > PROPERTYMAXLENGTH)
                return Errors.General.InvalidLength("street");
            if (building.Length is < 1 or > PROPERTYMAXLENGTH)
                return Errors.General.InvalidLength("building");
            if (index.Length is < 1 or > PROPERTYMAXLENGTH)
                return Errors.General.InvalidLength("index");
            
            return new Address(city, street, building, index);
        }                              
    }
}