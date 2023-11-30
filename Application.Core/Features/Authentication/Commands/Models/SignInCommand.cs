using Application.Core.Bases;
using Application.Data.Entities.Helpers;
using MediatR;

namespace Application.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : ResponseHandler, IRequest<Response<JwtAuthResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
