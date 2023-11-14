using Application.Core.Features.Users.Commands.Models;
using FluentValidation;

namespace Application.Core.Features.Users.Commands.Validatiors
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {

        public AddUserValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email must not be empty!")
                .NotNull().WithMessage("Email must not be null!")
                 ;

            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("{PropertyName} Password must not be empty!")
               .NotNull().WithMessage("{PropertyValue} must not be null!")
                ;

        }


    }
}
