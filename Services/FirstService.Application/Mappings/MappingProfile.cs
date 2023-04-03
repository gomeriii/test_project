using AutoMapper;
using EventBus.Messages.Events;
using FirstService.Application.Features.PersonalInfos.Commands.CreatePersonalInfo;

namespace FirstService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePersonalInfoCommand, CreatePersonalInfoEvent>();
        }
    }
}
