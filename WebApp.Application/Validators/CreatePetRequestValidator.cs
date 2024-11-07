using Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.ValueObjects;

namespace WebApp.Application.Validators
{
    public class CreatePetRequestValidator :AbstractValidator<CreatePetRequest>
    {
        public CreatePetRequestValidator() 
        {
            //TODO Написать валидацию для всех свойств
            RuleFor(x => x.Color).NotEmpty().MaximumLength(64);
            RuleFor(x => x.ContactPhoneNumber).MustBeValueObject(PhoneNumber.Create);
            RuleFor(x => x.VolunteerPhoneNumber).MustBeValueObject(PhoneNumber.Create);
            RuleFor(x=>x.Weight).MustBeValueObject(Weight.Create);
            
            RuleFor(x=> new {x.City, x.Street, x.Building,x.Index})
                .MustBeValueObject(x=> Address.Create(x.City,x.Street,x.Building,x.Index));

            RuleFor(x=>x.Place).MustBeValueObject(Place.Create);
        }  
    }
}
