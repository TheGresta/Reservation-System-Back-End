using FluentValidation;
using RezervationSystem.Dto.Concrete;

namespace RezervationSystem.Business.Validators.FluentValidation
{
    public class ReserRentWriteDtoValidator : AbstractValidator<ReserRentWriteDto>
    {
        public ReserRentWriteDtoValidator()
        {
            RuleFor(r => r.ReserId)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.StartDate)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.EndDate)
                .NotEmpty()
                .NotNull();
        }
    }
}
