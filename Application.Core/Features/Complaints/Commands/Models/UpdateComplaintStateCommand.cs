using MediatR;

namespace Application.Core.Features.Complaints.Commands.Models
{
    public class UpdateComplaintStateCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string Description { get; set; }
        public string? File { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }

        public string NewState { get; set; }


    }
}
