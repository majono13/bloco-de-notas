using Api.Data;
using Api.Data.Dtos.User;
using Api.Entities.Exceptions;
using Api.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Api.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private AppDbContext _appDbContext;

        public UserService(IMapper mapper, UserManager<IdentityUser<int>> userManager, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public bool IsvalidEmail(string email)
        {
            //E-mail vazio ou inválido
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"\w+[@]\w+[.]")) throw new InvalidEmailException("E-mail inválido");

            //E-mail já cadastrado
            User user_ = _appDbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user_ != null) throw new ExistsEmailException("E-mail já existente");

            return true;
        }

        public Result CreateNewUserIdentity(CreateUserDto userDto)
        {

            User user = _mapper.Map<User>(userDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);

            var resIdentity = _userManager.CreateAsync(userIdentity, userDto.Password);

            if (resIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao salvar novo usuário");
        }

        public Result CreateNewUser(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            if (IsvalidEmail(user.Email))
            {
                Result res = CreateNewUserIdentity(userDto);

                if (res.IsSuccess)
                {
                    _appDbContext.Users.Add(user);
                    _appDbContext.SaveChanges();
                    return Result.Ok();
                }

            }

            throw new InvalidOperationException("Internal server error");
        }
    }
}
