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
            name = name.Trim();
            if (name.Length is <1 or >100)
                return Errors.General.InvalidLength(name);

            return new Vaccination(name, applied);
        }

    }
}