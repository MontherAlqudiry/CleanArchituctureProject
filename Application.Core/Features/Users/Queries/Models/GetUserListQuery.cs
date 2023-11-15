using Application.Core.Features.Users.Queries.Responses;
using MediatR;

namespace Application.Core.Features.Users.Queries.Models
{
    public class GetUserListQuery : IRequest<List<GetUserListResponse>>
    {


    }
}
