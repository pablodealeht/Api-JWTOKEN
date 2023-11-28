using AutoMapper;
using Domain;

namespace Application.Handlers.Siniestros.Commands.Create;

public class CreateSiniestroCommandProfile : Profile
{
    public CreateSiniestroCommandProfile()
    {
        CreateMap<CreateSiniestroCommand, Siniestro>();
    }
}