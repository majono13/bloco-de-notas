using Api.Data.Dtos.Authentication;
using Api.Models.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Api.Data.Daos
{
    public class UserDao
    {

        private AppDbContext _appDbContext;
        private UserManager<IdentityUser<int>> _userManager;

        public UserDao(AppDbContext appDbContext, UserManager<IdentityUser<int>> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public User GetUserByEmail(string email)
        {
          return  _appDbContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public Task<IdentityResult> CreateNewUserIdentity(CreateUserDto userDto, IdentityUser<int> userIdentity)
        {

           return  _userManager.CreateAsync(userIdentity, userDto.Password);

        }

        public void CreateUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }

        public User GetUserById(int id)
        {
            User user = _appDbContext.Users.FirstOrDefault(user => user.Id == id);

            if(user !=null) return user;
            return null;
        }
    }
}
