using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
using Api.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
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
                ReadUserDto user = _loginService.Login(request);

                if (user == null) return Unauthorized("Login ou senha inválidos");

                return Ok(user);
            }
            catch (Exception)
            {

                return StatusCode(500, "Algo deu errado, tente novamente mais tarde.");
            }
       
        }

        [HttpPost("/token")]
        [Authorize] 
        public IActionResult VerifyToken(Token token)
        {
            try
            {
                User user = _loginService.GetUserByToken(token);

                if (user != null) return Ok(user);

                return Unauthorized();
            }
            catch
            {

                return StatusCode(500, "Algo deu errado, tente novamente mais tarde");
            }

        }
    }
}
