using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SecondService.Application.Contracts.Persistence;
using SecondService.Domain.Entities;

namespace SecondService.Application.Features.PersonalInfos.Commands.CreatePersonalInfo
{
    public class CreatePersonalInfoCommandHandler : IRequestHandler<CreatePersonalInfoCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePersonalInfoCommandHandler> _logger;
        private readonly IAsyncRepository<User> _userRepository;

        public CreatePersonalInfoCommandHandler(IMapper mapper, ILogger<CreatePersonalInfoCommandHandler> logger, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CreatePersonalInfoCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<User>(request);
            var newUser = await _userRepository.AddAsync(userEntity);

            _logger.LogInformation($"User {newUser.Id} is successfully sent");

            return Unit.Value;
        }
    }
}
