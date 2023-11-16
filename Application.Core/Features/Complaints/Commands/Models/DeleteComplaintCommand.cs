using MediatR;

namespace Application.Core.Features.Complaints.Commands.Models
{
    public class DeleteComplaintCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DeleteComplaintCommand(int id)
        {
            Id = id;
        }
    }
}
