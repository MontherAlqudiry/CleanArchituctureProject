using Application.Core.Features.Users.Queries.Responses;
using MediatR;

namespace Application.Core.Features.Users.Queries.Models

{
    public class GetUserByIDQuery : IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; }

        public GetUserByIDQuery(int id)
        {
            Id = id;
        }
    }
}
