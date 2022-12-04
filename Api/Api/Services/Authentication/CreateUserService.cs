using Api.Data;
using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Api.Services.Authentication
{
    public class CreateUserService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private AppDbContext _appDbContext;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CreateUserService(
            IMapper mapper, 
            UserManager<IdentityUser<int>> userManager, 
            AppDbContext appDbContext,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appDbContext = appDbContext;
            _roleManager = roleManager;
        }

        public Result CreateNewUserIdentity(CreateUserDto userDto)
        {

            User user = _mapper.Map<User>(userDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);

            var resIdentity = _userManager.CreateAsync(userIdentity, userDto.Password);

           _userManager.AddToRoleAsync(userIdentity, "user");

            if (resIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao salvar novo usuário");
        }

        public Result CreateNewUser(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            Result res = CreateNewUserIdentity(userDto);

            if (res.IsSuccess)
            {
                _appDbContext.Users.Add(user);
                _appDbContext.SaveChanges();
                return Result.Ok();
            }

            throw new InvalidOperationException("Algo deu errado, tente novamente mais tarde");
        }
    }
}
