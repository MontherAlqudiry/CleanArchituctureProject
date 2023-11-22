using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Core.Features.ApplicationUserCore.Commands.Models
{
    public class AddApplicationUserCommand : IRequest<string>
    {
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirm password don't match!")]
        public string ConfirmPassword { get; set; }


    }
}
