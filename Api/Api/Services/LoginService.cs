using Api.Data.Dtos.User;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Api.Services
{
    public class LoginService
    {

        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Login(LoginRequest request)
        {
            var resIdentity = _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);

            if (resIdentity.Result.Succeeded) return Result.Ok();

            return Result.Fail("E-mail ou senha inválidos");
        }
    }
}
