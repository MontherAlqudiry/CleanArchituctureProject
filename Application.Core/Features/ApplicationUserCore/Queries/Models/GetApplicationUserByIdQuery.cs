using Application.Core.Features.ApplicationUserCore.Queries.Responses;
using MediatR;

namespace Application.Core.Features.ApplicationUserCore.Queries.Models
{
    public class GetApplicationUserByIdQuery : IRequest<GetApplicationUserByIdResponse>
    {
        public int Id { get; set; }
        public GetApplicationUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
