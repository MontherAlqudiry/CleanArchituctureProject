using Application.Core.Features.ApplicationUserCore.Queries.Responses;
using MediatR;

namespace Application.Core.Features.ApplicationUserCore.Queries.Models
{
    public class GetApllicationUserListQuery : IRequest<List<GetApplicationUserListResponse>>
    {
    }
}
