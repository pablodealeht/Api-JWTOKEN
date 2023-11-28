using AutoMapper;
using Domain;


namespace Application.Handlers.Personal;

public class PersonalDtoProfile : Profile
{

    public PersonalDtoProfile()
    {
        CreateMap<RegPersonal, PersonalDto>();
    }
}
