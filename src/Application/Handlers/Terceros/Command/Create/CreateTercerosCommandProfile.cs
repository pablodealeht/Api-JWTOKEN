using AutoMapper;
using Domain;

namespace Application.Handlers.Terceros.Command.Create;

public class CreateTercerosCommandProfile : Profile
{
    public CreateTercerosCommandProfile()
    {
        CreateMap<CreateTercerosCommand, Tercero>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore());

        CreateMap<Tercero, TerceroDto>();
    }
}
