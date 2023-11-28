using MediatR;

namespace Application.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
