using Api.Services.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Authentication
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;
        public LogoutController(LogoutService logoutService)
        {
           _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult Logout()
        {


            try
            {
                Result res = _logoutService.Logout();
                if (res.IsFailed) return StatusCode(400, res.Reasons[0].Message);
                return StatusCode(200);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }

        }
    }
}
