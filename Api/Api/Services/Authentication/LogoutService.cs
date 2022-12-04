using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Api.Services.Authentication
{
    public class LogoutService
    {
        private readonly SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result Logout()
        {
            var resIdentity = _signInManager.SignOutAsync();

            if (resIdentity.IsCompletedSuccessfully) return Result.Ok();
            return Result.Fail("Falha ao realizar logout");
        }
    }
}
