using AutoMapper;
using EventBus.Messages.Events;
using SecondService.Application.Features.PersonalInfos.Commands.CreatePersonalInfo;
using SecondService.Application.Features.Queries.GetUserByOrganization;
using SecondService.Domain.Entities;

namespace SecondService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePersonalInfoEvent, CreatePersonalInfoCommand>();
            CreateMap<CreatePersonalInfoCommand, User>();
            CreateMap<User, UserOrganizationVM>();
        }
    }
}
