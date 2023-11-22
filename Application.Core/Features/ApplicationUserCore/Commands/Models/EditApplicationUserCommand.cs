using MediatR;

namespace Application.Core.Features.ApplicationUserCore.Commands.Models
{
    public class EditApplicationUserCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
