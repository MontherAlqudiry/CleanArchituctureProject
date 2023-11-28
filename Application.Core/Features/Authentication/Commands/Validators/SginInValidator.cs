using Application.Core.Features.Authentication.Commands.Models;
using FluentValidation;

namespace Application.Core.Features.Authentication.Commands.Validators
{
    public class SginInValidator : AbstractValidator<SignInCommand>
    {
        public SginInValidator()
        {
            ApplyValidationsRules();
        }
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("User Name or Email is required!");
            RuleFor(x => x.Email).NotNull().WithMessage("User Name or Email is required!");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required!");
            RuleFor(x => x.Email).NotNull().WithMessage("Password is required!");

        }
    }
}
