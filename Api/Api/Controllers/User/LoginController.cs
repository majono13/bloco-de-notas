using Api.Data.Dtos.User;
using Api.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            Result res = _loginService.Login(request);

            if(res.IsFailed) return Unauthorized();

            return Ok();
        }
    }
}
