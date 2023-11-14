using Application.Core.Features.Users.Commands.Models;
using Application.Core.Features.Users.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var response = await _mediator.Send(new GetUserListQuery());
            return Ok(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetUserByIDQuery(Id));
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] EditUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model state");
            }

            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
