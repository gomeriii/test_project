using MediatR;

namespace SecondService.Application.Features.PersonalInfos.Commands.LinkUserOrganization
{
    public class LinkUserOrganizationCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
    }
}