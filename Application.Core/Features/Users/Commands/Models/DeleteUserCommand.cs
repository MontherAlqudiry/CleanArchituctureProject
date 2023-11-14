using MediatR;

namespace Application.Core.Features.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<string>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }

    }
}
