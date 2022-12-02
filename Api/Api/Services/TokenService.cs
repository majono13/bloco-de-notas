using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services
{
    public class TokenService
    {

        public Token CreateToken(IdentityUser<int> user) 
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
    }
}
