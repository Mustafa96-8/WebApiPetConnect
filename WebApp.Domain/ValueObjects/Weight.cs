using CSharpFunctionalExtensions;
using WebApp.Domain.Common;

namespace WebApp.Domain.ValueObjects
{
    public record Weight
    {
       
        public Weight(float killograms)
        {
            Killograms = killograms;
        }
        public float Killograms { get; private set; }

        public static Result<Weight, Error> Create(float killograms) 
        {                       
            if (killograms < 0)
            {
                return Errors.General.ValueIsInvalid();
            }
            return new Weight(killograms);
        }

    }

}