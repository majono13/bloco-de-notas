using Api.Data.Dtos.User;
using Api.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/register")] 
        public IActionResult RegisterUser(CreateUserDto userDto)
        {
            Result res = _userService.CreateNewUser(userDto);

            if (res.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}
