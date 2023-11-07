using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Data.Entities;

namespace Application.Core.Features.Users.Queries.Models
{
    public class GetUserListQuery : IRequest<List<User>>
    {

    }
}
