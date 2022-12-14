using Api.Data;
using Api.Data.Daos;
using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Api.Services.Authentication
{
    public class LoginService
    {

        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;
        private IMapper _mapper;
        private UserDao _userDao;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService, IMapper mapper, UserDao userDao)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
            _userDao = userDao;
        }

        public ReadUserDto Login(LoginRequest request)
        {
            var resIdentity = _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (resIdentity.Result.Succeeded)
            {
                IdentityUser<int> identityUser = _signInManager.UserManager.Users
                    .FirstOrDefault(user => user.NormalizedEmail == request.Email.ToUpper());

                ReadUserDto readUser = TransformUserProfile(identityUser);

                return readUser;
            }
            return null;
        }

        private ReadUserDto TransformUserProfile(IdentityUser<int> identityUser)
        {
            User user = _userDao.GetUserByEmail(identityUser.Email);

            if(user != null)
            {
                ReadUserDto readUser = _mapper.Map<ReadUserDto>(user);
                Token token = GenerateToken(user);
                readUser.Token = token.Value;

                return readUser;
            }
     
            return null;

        }

        private Token GenerateToken(User user)
        {
            return _tokenService.CreateToken(user);
        }

        public User GetUserByToken(Token token)
        {
            User user = _tokenService.GetUserByToken(token);

            if (user != null) return user;
            return null;
        }
    }
}