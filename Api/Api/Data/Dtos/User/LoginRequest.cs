using System.ComponentModel.DataAnnotations;

namespace Api.Data.Dtos.User
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
