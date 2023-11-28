using AutoMapper;
using Domain;
using Humanizer;

namespace Application.Handlers.Siniestros.Queries;

public class SiniestroDtoProfile : Profile
{
    public SiniestroDtoProfile()
    {
        CreateMap<Siniestro, SiniestroDto>()
            .ForMember(dest => dest.Estado,
                opt => opt.MapFrom(src => src.Estado.Humanize()));
    }
}