using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using SecondService.Application.Features.PersonalInfos.Commands.LinkUserOrganization;
using SecondService.Application.Features.Queries.GetUserByOrganization;

namespace SecondService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<IList<UserOrganizationVM>>> GetUsers([FromBody] GetUserByOrganizationQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Link")]
        public async Task<ActionResult<Unit>> GetUsers([FromBody] LinkUserOrganizationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
