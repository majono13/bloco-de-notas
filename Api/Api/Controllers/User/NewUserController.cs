using Api.Data.Dtos.User;
using Api.Entities.Exceptions;
using Api.Models;
using Api.Services;
using Api.Validators;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private     CreateUserService _userService;
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

                    if (res.IsFailed) return StatusCode(500);
                    return Ok();
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

