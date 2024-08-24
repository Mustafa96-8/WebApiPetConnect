using System.Text.RegularExpressions;

namespace WebApp.Domain.ValueObjects
{
    public record PhoneNumber
    {
        private const string russionPhoneRegex = @"^((8|\+7)[\-]?)?(\(?\d{3}\)?[\-]?)?[\d\- ]{7,10}$";

        public string Number {  get; private set; }

        public PhoneNumber(string number)
        {
            Number = number;
        }
        public static PhoneNumber Create(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }
            if (Regex.IsMatch(input, russionPhoneRegex) == false)
            {
                throw new ArgumentException();
            }
            return new (input);
        }

    }
}