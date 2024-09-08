using AutoMapper;
using Users_Api.Db;

namespace Users_Api.Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>()
                 .ForMember(dest => dest.Id, opts => opts.Ignore())
                 .ForMember(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
                 .ForMember(dest => dest.Name, opts => opts.MapFrom(x => x.Name))
                 .ForMember(dest => dest.Surname, opts => opts.MapFrom(x => x.FamilyName))
                 .ForMember(dest => dest.Registred, opts => opts.Ignore())
                 .ForMember(dest => dest.Active, opts => opts.Ignore())
                 .ReverseMap();
        }
    }
}
