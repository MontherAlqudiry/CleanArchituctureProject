using Application.Core.Features.Complaints.Queries.Responses;
using MediatR;

namespace Application.Core.Features.Complaints.Queries.Models
{
    public class GetComplaintListByUserIdQuery : IRequest<List<GetComplaintByUserIdResponse>>
    {
        public int UserId { get; set; }
        public GetComplaintListByUserIdQuery(int userid)
        {
            UserId = userid;
        }

    }
}
