using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Core.Features.ApplicationUserCore.Commands.Models
{
    public class ChangePasswordApplicationUserCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        [Compare("NewPassword", ErrorMessage = "The new Password and confirm new Password don't match!")]
        public string ConfirmNewPassword { get; set; }

    }
}
