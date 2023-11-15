using Application.Core.Features.Complaints.Queries.Responses;
using MediatR;

namespace Application.Core.Features.Complaints.Queries.Models
{
    public class GetComplaintByIdQuery : IRequest<GetComplaintByIdResponse>
    {
        public int Id { get; set; }
        public GetComplaintByIdQuery(int id)
        {
            Id = id;
        }
    }
}
