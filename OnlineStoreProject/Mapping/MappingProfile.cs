using AutoMapper;
using OnlineStoreProject.Models;
using OnlineStoreProject.Resources;

namespace OnlineStoreProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserSignUpResource, OnlineStoreUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}