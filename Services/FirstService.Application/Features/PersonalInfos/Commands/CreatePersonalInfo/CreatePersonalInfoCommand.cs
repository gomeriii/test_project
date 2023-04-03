using MediatR;

namespace FirstService.Application.Features.PersonalInfos.Commands.CreatePersonalInfo
{
    public class CreatePersonalInfoCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}