using MediatR;
using System.Collections.Generic;

namespace SecondService.Application.Features.Queries.GetUserByOrganization
{
    public class GetUserByOrganizationQuery : IRequest<IList<UserOrganizationVM>>
    {
        public int OrganizationId { get; set; }

        public int Offset { get; set; }

        public int Count { get; set; }
    }
}