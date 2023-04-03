using System.Threading.Tasks;
using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using SecondService.Application.Features.PersonalInfos.Commands.CreatePersonalInfo;

namespace SecondService.EventBusConsumer
{
    public class CreatePersonalInfoConsumer : IConsumer<CreatePersonalInfoEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonalInfoConsumer> _logger;

        public CreatePersonalInfoConsumer(IMediator mediator, IMapper mapper, ILogger<CreatePersonalInfoConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CreatePersonalInfoEvent> context)
        {
            var command = _mapper.Map<CreatePersonalInfoCommand>(context.Message);
            var result = await _mediator.Send(command);

            _logger.LogInformation("CreatePersonalInfoEvent consumed successfully.");
        }
    }
}
