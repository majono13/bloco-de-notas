using Api.Models.Authentication;
using Api.Models.Notes;

namespace Api.Data.Dtos.Authentication
{
    public class ReadUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; } 
    }
}
