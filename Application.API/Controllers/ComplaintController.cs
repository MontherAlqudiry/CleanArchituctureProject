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

    }
}
