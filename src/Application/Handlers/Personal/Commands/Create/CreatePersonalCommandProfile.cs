using Application.Handlers.Terceros;
using AutoMapper;
using Domain;

namespace Application.Handlers.Personal.Commands.Create;

public class CreatePersonalCommandProfile : Profile
{
    public CreatePersonalCommandProfile()
    {
        CreateMap<CreatePersonalCommand, RegPersonal>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore()); ;

        CreateMap<RegPersonal, PersonalDto>();
    }
}
