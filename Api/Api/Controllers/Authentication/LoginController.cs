using Api.Data.Dtos.Authentication;
using Api.Services.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Authentication
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

            try
            {
                Result res = _loginService.Login(request);

                if (res.IsFailed) return StatusCode(400, "Login ou senha inválidos");

                return Ok(res.Reasons[0].Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
       
        }
    }
}
