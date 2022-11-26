﻿using Api.Data;
using Api.Data.Dtos.User;
using Api.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Api.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<int>> _userManager;
        private AppDbContext _appDbContext;

        public UserService(IMapper mapper, UserManager<IdentityUser<int>> userManager, AppDbContext appDbContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        internal Result CreateNewUserIdentity(CreateUserDto userDto)
        {

            User user = _mapper.Map<User>(userDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);

            var resIdentity = _userManager.CreateAsync(userIdentity, userDto.Password);

            if (resIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao salvar novo usuário");
        }

        public Result CreateNewUser(CreateUserDto userDto)
        {
            try
            {
                Result res = CreateNewUserIdentity(userDto);
                User user = _mapper.Map<User>(userDto);

                if (res.IsSuccess)
                {
                    _appDbContext.Users.Add(user);
                    _appDbContext.SaveChanges();
                    return Result.Ok();
                }

                return Result.Fail("Falha ao salvar novo usuário");
            }
            catch
            {
                return Result.Fail("Internal server error");
            }

        }
    }
}
