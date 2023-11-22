using Application.Core.Features.ApplicationUserCore.Commands.Models;
using Application.Core.Features.ApplicationUserCore.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicationUser([FromBody] AddApplicationUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetApplicationUserList()
        {
            var response = await _mediator.Send(new GetApllicationUserListQuery());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetApplicationUserByID([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetApplicationUserByIdQuery(Id));
            if (response == null)
            {
                return BadRequest($"No Application User with the given ID : {Id}");
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> EditApplicationUser([FromBody] EditApplicationUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApplicationUser([FromBody] DeleteApplicationUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
