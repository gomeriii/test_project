using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SecondService.Application.Contracts.Persistence;
using SecondService.Application.Exceptions;
using SecondService.Domain.Entities;

namespace SecondService.Application.Features.PersonalInfos.Commands.LinkUserOrganization
{
    public class LinkUserOrganizationCommandHandler : IRequestHandler<LinkUserOrganizationCommand>
    {
        private readonly ILogger<LinkUserOrganizationCommandHandler> _logger;
        private readonly IAsyncRepository<Organization> _organizationRepository;
        private readonly IAsyncRepository<User> _userRepository;

        public LinkUserOrganizationCommandHandler(ILogger<LinkUserOrganizationCommandHandler> logger,
            IAsyncRepository<Organization> organizationRepository, IAsyncRepository<User> userRepository)
        {
            _logger = logger;
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(LinkUserOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.OrganizationId);
            if (organization == null)
            {
                throw new NotFoundException(nameof(Organization), request.OrganizationId);
            }

            var user = await _userRepository.GetByIdAsync(request.OrganizationId);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserId);
            }

            user.OrganizationId = organization.Id;
            await _userRepository.UpdateAsync(user);

            _logger.LogInformation($"User [{user.Id}] is successfully updated, linked organization [{organization.Id}]");

            return Unit.Value;
        }
    }
}