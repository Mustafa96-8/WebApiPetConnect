using Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Application.Validators
{
    public class CreatePetRequestValidator :AbstractValidator<CreatePetRequest>
    {
        public CreatePetRequestValidator() 
        {
            RuleFor(x => x.Nickname).NotEmpty();
        }  
    }
}
