using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(d => d.FirstName).NotEmpty();
            RuleFor(d => d.LastName).NotEmpty();
            RuleFor(d => d.FirstName).MinimumLength(2);
            RuleFor(d => d.TC).MinimumLength(11).MaximumLength(11).WithMessage("Lütfen TC kimlik numaranızın doğruluğundan emin olunuz");
        }
    }

}
