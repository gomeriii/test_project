using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FirstService.Application.Features.PersonalInfos.Commands.CreatePersonalInfo;
using MediatR;

namespace FirstService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonalInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<Unit>> CreatePersonInfo([FromBody] CreatePersonalInfoCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
