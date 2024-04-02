using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PatientValidator:AbstractValidator<Patient>
    {
        public PatientValidator() 
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(2);
            RuleFor(p => p.TC).MinimumLength(11).MaximumLength(11).WithMessage("Lütfen TC kimlik numaranızın doğruluğundan emin olunuz");
        }
    }
}
