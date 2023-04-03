using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FirstService.Application.Features.PersonalInfos.Commands.CreatePersonalInfo
{
    public class CreatePersonalInfoCommandHandler : IRequestHandler<CreatePersonalInfoCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonalInfoCommandHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreatePersonalInfoCommandHandler(IMapper mapper, ILogger<CreatePersonalInfoCommandHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Unit> Handle(CreatePersonalInfoCommand request, CancellationToken cancellationToken)
        {
            var eventModel = _mapper.Map<CreatePersonalInfoEvent>(request);

            await _publishEndpoint.Publish(eventModel, cancellationToken);

            _logger.LogInformation($"CreatePersonalInfoEvent {eventModel.Id} is successfully sent");

            return Unit.Value;
        }
    }
}
