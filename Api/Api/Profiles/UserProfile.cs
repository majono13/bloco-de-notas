using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
            CreateMap<User, ReadUserDto>();
            CreateMap<CreateUserDto, IdentityUser<int>>();
        }
    }
}
