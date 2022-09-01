using FluentValidation;
using RezervationSystem.Dto.Concrete;

namespace RezervationSystem.Business.Validators.FluentValidation
{
    public class ReserWriteDtoValidator : AbstractValidator<ReserWriteDto>
    {
        public ReserWriteDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Name)
                .MaximumLength(50);

            RuleFor(r => r.Name)
                .MinimumLength(2);


            RuleFor(r => r.Address)
                .MaximumLength(250);


            RuleFor(r => r.Descripton)
                .MaximumLength(250);

            RuleFor(r => r.Price)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Price)
                .GreaterThan(0);
        }
    }
}
