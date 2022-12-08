using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
using Api.Entities.Exceptions;
using Api.Services.Authentication;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Api.Data.Daos;
using AutoMapper;

namespace Api.Controllers.Authentication
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private CreateUserService _userService;
        private UserValidator _validator;
 

        public UserController(CreateUserService userService, UserValidator validator)
        {
            _userService = userService;
            _validator = validator;
        }

        [HttpPost("/register")]
        public IActionResult RegisterUser(CreateUserDto userDto)
        {
            try
            {

                if (_validator.UnregisteredEmail(userDto.Email))
                {

                    Result res = _userService.CreateNewUser(userDto);

                    if (res.IsFailed) return StatusCode(500, "Internal server error");
                    return StatusCode(200);
                }

                throw new ExistsEmailException("E-mail já cadastrado");
            }
            catch (ExistsEmailException e)
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

