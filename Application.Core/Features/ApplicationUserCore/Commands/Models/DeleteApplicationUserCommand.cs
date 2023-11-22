using MediatR;

namespace Application.Core.Features.ApplicationUserCore.Commands.Models
{
    public class DeleteApplicationUserCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DeleteApplicationUserCommand(int id)
        {
            Id = id;
        }

    }
}
