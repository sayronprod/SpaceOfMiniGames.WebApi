using AutoMapper;
using SpaceOfMiniGames.WebApi.Models;
using SpaceOfMiniGames.WebApi.Models.ModelsDbo;

namespace SpaceOfMiniGames.WebApi.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserDbo, User>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(so => so.UserRoles.Select(t => t.RoleName).ToList()))
                .ReverseMap();
        }
    }
}
