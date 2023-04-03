using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SecondService.Application.Contracts.Persistence;
using SecondService.Application.Exceptions;
using SecondService.Domain.Entities;

namespace SecondService.Application.Features.Queries.GetUserByOrganization
{
    public class GetUserByOrganizationQueryHandler : IRequestHandler<GetUserByOrganizationQuery, IList<UserOrganizationVM>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserByOrganizationQueryHandler> _logger;
        private readonly IAsyncRepository<Organization> _organizationRepository;
        private readonly IUserRepository _userRepository;

        public GetUserByOrganizationQueryHandler(IMapper mapper, ILogger<GetUserByOrganizationQueryHandler> logger,
            IAsyncRepository<Organization> organizationRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _logger = logger;
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
        }

        public async Task<IList<UserOrganizationVM>> Handle(GetUserByOrganizationQuery request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.OrganizationId);
            if (organization == null)
            {
                throw new NotFoundException(nameof(Organization), request.OrganizationId);
            }

            var users = await _userRepository.GetByOrganizationAsync(organization.Id, request.Offset, request.Count);
            var mapped = _mapper.Map<IList<UserOrganizationVM>>(users);
            return mapped;
        }
    }
}