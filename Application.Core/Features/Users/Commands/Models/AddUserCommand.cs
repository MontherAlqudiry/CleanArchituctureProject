using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Core.Features.Users.Commands.Models
{
    public class AddUserCommand : IRequest<string>
    {
        public string FName { get; set; }

        public string LName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string? File { get; set; }

        public string Role { get; set; } 

     
    }
}
