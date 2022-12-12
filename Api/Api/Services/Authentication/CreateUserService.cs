using Api.Data.Daos;
using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Api.Services.Authentication
{
    public class CreateUserService
    {
        private IMapper _mapper;
        private UserDao _dao;

        public CreateUserService(
            IMapper mapper, 
            UserDao dao)
        {
            _mapper = mapper;
            _dao = dao;
        }

        private Result CreateNewUserIdentity(CreateUserDto userDto)
        {

            User user = _mapper.Map<User>(userDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(userDto);

            var resIdentity = _dao.CreateNewUserIdentity(userDto, userIdentity);

            if (resIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao salvar novo usuário");
        }

        public Result CreateNewUser(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);

            Result res = CreateNewUserIdentity(userDto);

            if (res.IsSuccess)
            {
                _dao.CreateUser(user);
                return Result.Ok();
            }

            throw new InvalidOperationException("Algo deu errado, tente novamente mais tarde");
        }
    }
}
