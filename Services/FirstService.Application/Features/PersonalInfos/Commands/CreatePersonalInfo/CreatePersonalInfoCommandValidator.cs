using FluentValidation;

namespace FirstService.Application.Features.PersonalInfos.Commands.CreatePersonalInfo
{
    public class CreatePersonalInfoCommandValidator : AbstractValidator<CreatePersonalInfoCommand>
    {
        public CreatePersonalInfoCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull();
            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("{Surname} is required.")
                .NotNull();
            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PhoneNumber} is required.")
                .NotNull();
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{Email} is required.")
                .NotNull();
        }
    }
}