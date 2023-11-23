using Application.Core.Features.ApplicationUserCore.Commands.Models;
using FluentValidation;

namespace Application.Core.Features.ApplicationUserCore.Commands.Validators
{
    public class ChangePasswordApplicationUserValidator : AbstractValidator<ChangePasswordApplicationUserCommand>
    {

        public ChangePasswordApplicationUserValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Current Password is requierd!")
                                         .NotNull().WithMessage("Current Password is requierd!");

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New Password is requierd!")
                                       .NotNull().WithMessage("new Password is requierd!");

            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Confirm Password is requierd!")
                                           .NotNull().WithMessage("Confirm Password is requierd!")
                                           .Equal(x => x.NewPassword).WithMessage("The New Password must equals the confirm password!");

        }
    }
}
