using Application.Core.Features.Complaints.Queries.Responses;
using MediatR;

namespace Application.Core.Features.Complaints.Queries.Models
{
    public class GetComplaintsListQuery : IRequest<List<GetComplaintListResponse>>
    {


    }
}
