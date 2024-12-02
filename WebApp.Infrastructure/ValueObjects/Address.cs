using CSharpFunctionalExtensions;
using WebApp.Domain.Common;

namespace WebApp.Domain.ValueObjects
{
    public record Address
    {
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
            if (city.IsEmpty()) 
                return Errors.General.ValueIsRequired();
            if (street.IsEmpty()) 
                return Errors.General.ValueIsRequired();
            if (building.IsEmpty()) 
                return Errors.General.ValueIsRequired();
            if (index.IsEmpty()) 
                return Errors.General.ValueIsRequired();

            return new Address(city, street, building, index);
        }

    }
}