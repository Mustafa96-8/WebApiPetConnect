using CSharpFunctionalExtensions;
using WebApp.Domain.Common;

namespace WebApp.Domain.Entities
{
    public class Vaccination
    {
        private Vaccination( string name, DateTime applied)
        {
            Name = name;
            Applied = applied;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public DateTime Applied {  get; private set; }
        public static Result<Vaccination, Error> Create(string name, DateTime applied)
        {
            if (name.IsEmpty())
                return Errors.General.ValueIsRequired(name);

            return new Vaccination(name, applied);
        }

    }
}