using Api.Data.Dtos.User;
using Api.Entities.Exceptions;
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
            try
            {
                Result res = _userService.CreateNewUser(userDto);


                if (res.IsFailed) return StatusCode(500);
                return Ok();
            }
            catch (ExistsEmailException e)
            {
                return StatusCode(406, e.Message);
            }
            catch (InvalidEmailException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
