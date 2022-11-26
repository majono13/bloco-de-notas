using Api.Data.Dtos.User;
using Api.Models;
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
        }
    }
}
