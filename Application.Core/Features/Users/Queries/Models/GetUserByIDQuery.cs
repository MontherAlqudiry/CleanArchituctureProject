using Application.Core.Bases;
using Application.Core.Features.Users.Queries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Features.Users.Queries.Models

{
    public class GetUserByIDQuery :IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; }

        public GetUserByIDQuery(int id)
        {
            Id = id;
        }
    }
}
