using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Api.Services.Authentication
{
    public class LoginService
    {

        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public Result Login(LoginRequest request)
        {
            var resIdentity = _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (resIdentity.Result.Succeeded)
            {
                IdentityUser<int> identityUser = _signInManager.UserManager.Users
                    .FirstOrDefault(user => user.NormalizedEmail == request.Email.ToUpper());

                Token token = _tokenService.CreateToken(identityUser, 
                    _signInManager.UserManager.GetRolesAsync(identityUser).Result.FirstOrDefault());

                return Result.Ok().WithSuccess(token.Value);
            }
            return Result.Fail("E-mail ou senha inválidos");
        }
    }
}