using Application.Core.Features.Complaints.Commands.Models;
using Application.Core.Features.Complaints.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComplaintController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetComplaintList()
        {
            var response = await _mediator.Send(new GetComplaintsListQuery());
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetComplaintByID([FromRoute] int Id)
        {
            var response = await _mediator.Send(new GetComplaintByIdQuery(Id));

            if (response == null)
            {
                return BadRequest($"There is no Complaint with the given Id : {Id}");
            }

            return Ok(response);


        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetComplaintByUserId([FromRoute] int UserId)
        {
            var response = await _mediator.Send(new GetComplaintListByUserIdQuery(UserId));
            if (response == null || response.Count() == 0)
            {
                return BadRequest($"There is no Complaint with the given User Id : {UserId}");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddComplaint([FromBody] AddComplaintCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteComplaint([FromRoute] int Id)
        {
            var response = await _mediator.Send(new DeleteComplaintCommand(Id));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComplaintState([FromBody] UpdateComplaintStateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
