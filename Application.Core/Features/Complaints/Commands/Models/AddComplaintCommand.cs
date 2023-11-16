using Application.Data.Entities;
using MediatR;

namespace Application.Core.Features.Complaints.Commands.Models
{
    public class AddComplaintCommand : IRequest<string>
    {

        public string? Title { get; set; }
        public string? Type { get; set; }
        public string Description { get; set; }
        public string? File { get; set; }
        public int? UserId { get; set; }
        public virtual ICollection<Demand>? Demands { get; set; }
    }
}
