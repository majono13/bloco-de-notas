using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
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
        public ActionResult<Token> Login(LoginRequest request)
        {

            try
            {
                Result res = _loginService.Login(request);

                if (res.IsFailed) return Unauthorized("Login ou senha inválidos");

                Token token = new Token(res.Reasons[0].Message);

                return Ok(token);
            }
            catch (Exception)
            {

                return StatusCode(500, "Algo deu errado, tente novamente mais tarde.");
            }
       
        }
    }
}
