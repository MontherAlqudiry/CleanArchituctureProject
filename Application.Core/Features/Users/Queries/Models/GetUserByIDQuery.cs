using Application.Core.Bases;
using Application.Core.Features.Users.Queries.Responses;
using MediatR;

namespace Application.Core.Features.Users.Queries.Models

{
    public class GetUserByIDQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }

        public GetUserByIDQuery(int id)
        {
            Id = id;
        }
    }
}
