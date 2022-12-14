using Api.Data.Daos;
using Api.Entities.Exceptions;
using Api.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services.Authentication
{
    public class TokenService
    {

        private UserDao _userDao;

        public TokenService()
        {
        }

        public TokenService(UserDao userDao)
        {
            _userDao = userDao;
        }

        public Token CreateToken(User user)
        {
            Claim[] lawUser = new Claim[]
            {
                new Claim("email", user.Email),
                new Claim("id", user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("kjdf2i235wqiuyasjh1o387465kqw219jKJtRERsoihoeftrqscjlqd")
                );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: lawUser,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddMonths(3)
                );

            return new Token(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public string GetUserIdByToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken securityToken = tokenHandler.ReadJwtToken(token);
            IEnumerable<Claim> claims = securityToken.Claims;

            foreach(Claim claim in claims)
            {
                if (claim.Type == "id") return claim.Value;
            };

            return null;
        }


        public User GetUserByToken(Token token)
        {
            int id = int.Parse(GetUserIdByToken(token.Value));

            User user = _userDao.GetUserById(id);

            if (user != null) return user;

            throw new UnauthorizedIdRequest("Ação não permitida");

        }
    }
}
